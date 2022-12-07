using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootingTemplate 
{
    PlayerShootingManager currentPlayerShooting;

    public delegate void EndShootingSM();
    public static event EndShootingSM OnEndShooting;

    public PlayerShootingManager CurrentPlayerShooting
    {
        get
        {
            return currentPlayerShooting;
        }
    }
    public virtual PlayerShootingManager ShootingPlayer
    {
        get
        {
            OnEndShooting?.Invoke();
            PlayerShootingSM.OnShootingAction -= ExitShootingSM;
            return null;
        }
        set
        {
            if (value != null)
            {
                PlayerShootingSM.OnShootingAction += ExitShootingSM;
            }
            currentPlayerShooting = value;
        }
    }
    void ExitShootingSM()
    {
        currentPlayerShooting = ShootingPlayer;
    }
}
