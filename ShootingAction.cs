using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAction 
{
    ShootingMode currentShootingMode;

    public delegate void ShootingActions();
    public static event ShootingActions OnShootingActions;
    public ShootingMode CurrentShootingMode
    {
        get
        {
            PlayerMovementSM.OnMovementSMAction -= ExitWithoutShooting;
            PlayerMovement.OnPlayerPressFireButton -= PlayerShooting;
            return currentShootingMode;
        }
        set
        {
            if (value != null)
            {
                PlayerMovementSM.OnMovementSMAction += ExitWithoutShooting;
                PlayerMovement.OnPlayerPressFireButton += PlayerShooting;
            }
            else
            {
                currentShootingMode = CurrentShootingMode;
            }
            currentShootingMode = value;
        }
    }
    ShootingMode CurrentShootingModeShooting
    {
        get
        {
            PlayerShootingSM.OnShootingAction -= ExitShootingAction;
            return null;
        }
        set
        {
            OnShootingActions?.Invoke();
            PlayerShootingSM.OnShootingAction += ExitShootingAction;
        }
    }
    void ExitWithoutShooting()
    {
        CurrentShootingMode = null;
    }
    void PlayerShooting(PlayerShootingManager currenPlayerShooting)
    {
        currentShootingMode.CurrentShootingManager = currenPlayerShooting;
        CurrentShootingModeShooting = CurrentShootingMode;
    }
    void ExitShootingAction()
    {
        currentShootingMode = CurrentShootingModeShooting;
    }
}