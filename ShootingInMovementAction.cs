using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingInMovementAction <T> where T:PlayerMovementSM
{
    T playerInShootingSM;

    public delegate void StayableAnimationAction();
    public StayableAnimationAction OnBeginShootingInMovement;

    bool StayableMode
    {
        get
        {
            return playerInShootingSM.GetType().IsSubclassOf(typeof(T));
        }
    }
    public T PlayerInShootingSM
    {
        get
        {
            if(StayableMode) PlayerMovement.OnPlayerPressFireButton -= ShootingInMovement;
            PlayerShootingSM.OnShootingAction -= EndShootingInMovement;
            return playerInShootingSM;
        }
        set
        {
            if(value.GetType().IsSubclassOf(typeof(T)))
            {
                OnBeginShootingInMovement?.Invoke();
                PlayerMovement.OnPlayerPressFireButton += ShootingInMovement;
            }
            PlayerShootingSM.OnShootingAction += EndShootingInMovement;
            playerInShootingSM = value;
            OnBeginShootingInMovement = null;
        }
    }
    void ShootingInMovement(PlayerShootingManager currentShootingManager)
    {
        currentShootingManager.Shot();
    }
    void EndShootingInMovement()
    {
        PlayerInShootingSM.PlayerEndShooting();
        playerInShootingSM = null;
    }
}
