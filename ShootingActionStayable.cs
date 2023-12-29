using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingActionStayable : ShootingAction
{
    public new PlayerShootingManager CurrentShootingManager
    {
        get
        {
            PlayerShootingSM.OnShootingAction -= BeginStayableMode;
            return currentShootingManager;
        }
        set
        {
            if (value != null)
            {
                StayableShooting(value);
            }
            PlayerShootingSM.OnShootingAction += BeginStayableMode;
            currentShootingManager = value;
        }
    }
    PlayerShootingManager ShootingStayableMode
    {
        get
        {
            PlayerMovement.OnPlayerPressFireButton -= StayableShooting;
            OnEndShootingState -= EndStayableMode;
            return currentShootingManager;
        }
        set
        {
            if (value != null) 
            {
                PlayerMovement.OnPlayerPressFireButton += StayableShooting;
                OnEndShootingState += EndStayableMode;
                ExitShootingSM = value;
            }
        }
    }
    void BeginStayableMode()
    {
        ShootingStayableMode = CurrentShootingManager;
    }
    void StayableShooting(PlayerShootingManager currentShootingManager)
    {
        currentShootingManager.Shot();
        currentShootingManager.CalculateTimeForNextShot();
    }
    void EndStayableMode()
    {
        currentShootingManager = ShootingStayableMode;
    }
}