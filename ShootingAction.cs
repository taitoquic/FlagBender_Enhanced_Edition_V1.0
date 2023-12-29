using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShootingAction 
{
    public PlayerShootingManager currentShootingManager;

    public delegate void ShootingActions();
    public static event ShootingActions OnEndShootingState;
    public PlayerShootingManager PlayerExitShooting
    {
        get
        {
            OnEndShootingState?.Invoke();
            currentShootingManager.OnResumeMovementAtEndShot.Invoke();
            return null;
        }
    }
    public PlayerShootingManager CurrentShootingManager
    {
        get
        {
            PlayerShootingSM.OnShootingAction -= StandShot;
            return currentShootingManager;
        }
        set
        {
            if (value != null)
            {
                value.CalculateTimeForNextShot();
                value.OnStopPlayerAtBeginShot.Invoke();
            }
            PlayerShootingSM.OnShootingAction += StandShot;
            currentShootingManager = value;
        }
    }
    public PlayerShootingManager ExitShootingSM
    {
        get
        {
            PlayerShootingSM.OnShootingAction -= ExitShootingState;
            return PlayerExitShooting;
        }
        set
        {
            PlayerShootingSM.OnShootingAction += ExitShootingState;
        }
    }

    void StandShot()
    {
        ExitShootingSM = CurrentShootingManager;
    }
    public void ExitShootingState()
    {
        currentShootingManager = ExitShootingSM;
    }
}