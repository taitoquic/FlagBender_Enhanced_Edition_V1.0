using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAction 
{
    int shootingModeIndex;
    ShootingMode[] shootingModes = new ShootingMode[2] { new ShootingModeStand(), new ShootingModeStayable() };
    ShootingMode currentShootingMode;
    //PlayerShootingManager playerShootingManager;
    //ShootingStand shootingStand = new ShootingStand();
    //ShootingStayable shootingStayable = new ShootingStayable();

    //public delegate void ShootingActions();
    //public static event ShootingActions OnShootingActions;

    public int ShootingModeIndex
    {
        set
        {
            shootingModeIndex = value == 0 ? 0 : 1;
            CurrentShootingMode = shootingModes[shootingModeIndex];
        }
    }
    public ShootingMode CurrentShootingMode
    {
        get
        {
            PlayerMovement.OnPlayerPressFireButton -= PlayerShooting;
            return currentShootingMode;
        }
        set
        {
            PlayerMovement.OnPlayerPressFireButton += PlayerShooting;
            currentShootingMode = value;
        }
    }

    //public PlayerShootingManager PlayerShootingManager
    //{
    //    get
    //    {
    //        PlayerShootingSM.OnShootingAction -= AfterFirstShot;
    //        return playerShootingManager;
    //    }
    //    set
    //    {
    //        if (value != null)
    //        {
    //            //value.FirstShot();
    //            OnShootingActions?.Invoke();
    //            PlayerShootingSM.OnShootingAction += AfterFirstShot;
    //        }
    //        playerShootingManager = value;
    //    }
    //}
    void PlayerShooting(PlayerShootingManager currenPlayerShooting)
    {
        CurrentShootingMode.CurrentShootingManager = currenPlayerShooting;
    }
    //void AfterFirstShot()
    //{
    //    if (PlayerShootingManager.IsShootingInAnimation)
    //    {
    //        //shootingStand.ShootingPlayer = playerShootingManager;
    //    }
    //    else
    //    {
    //        //shootingStayable.ShootingPlayer = playerShootingManager;
    //    }
    //    playerShootingManager = null;
    //}
}