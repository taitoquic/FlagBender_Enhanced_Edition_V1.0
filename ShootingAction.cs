using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAction 
{
    PlayerShootingManager playerShootingManager;

    public delegate void ShootingActions();
    public static event ShootingActions OnShootingActions;

    public PlayerShootingManager PlayerShootingManager
    {
        get
        {
            PlayerShootingSM.OnShootingAction -= AfterFirstShot;
            return playerShootingManager;
        }
        set
        {
            if (value != null)
            {
                value.FirstShot();
                OnShootingActions?.Invoke();
                PlayerShootingSM.OnShootingAction += AfterFirstShot;
            }
            playerShootingManager = value;
        }
    }
    PlayerShootingManager StandShot
    {
        get
        {
            PlayerShootingSM.OnShootingAction -= ExitStandShooting;
            OnShootingActions?.Invoke();
            return null;
        }
        set
        {
            if(value != null)
            {
                value.OnShooting = null;
                PlayerShootingSM.OnShootingAction += ExitStandShooting;
            }
        }
    }
    PlayerShootingManager StayableShooting
    {
        get
        {
            PlayerMovement.OnPlayerPressFireButton -= StayableMode;
            PlayerShootingSM.OnShootingAction -= ExitStayableShooting;
            playerShootingManager.OnShooting = null;
            OnShootingActions?.Invoke();
            return null;
        }
        set
        {
            PlayerMovement.OnPlayerPressFireButton += StayableMode;
            PlayerShootingSM.OnShootingAction += ExitStayableShooting;
        }
    }
    void AfterFirstShot()
    {
        if (PlayerShootingManager.IsShootingInAnimation)
        {
            StandShot = PlayerShootingManager;
        }
        else
        {
            StayableShooting = PlayerShootingManager;
        }
    }
    void ExitStandShooting()
    {
        playerShootingManager = StandShot;
    }
    void StayableMode(PlayerShootingManager currentPlayerShooting)
    {
        currentPlayerShooting.TriggerOn();
    }
    void ExitStayableShooting()
    {
        playerShootingManager = StayableShooting;
    }
}