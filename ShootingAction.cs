using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAction 
{
    PlayerShootingManager playerShootingManager;
    ShootingStand shootingStand = new ShootingStand();
    ShootingStayable shootingStayable = new ShootingStayable();

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
    void AfterFirstShot()
    {
        if (PlayerShootingManager.IsShootingInAnimation)
        {
            shootingStand.ShootingPlayer = playerShootingManager;
        }
        else
        {
            shootingStayable.ShootingPlayer = playerShootingManager;
        }
        playerShootingManager = null;
    }
}