using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootingMode 
{
    PlayerShootingManager currentShootingManager;

    public delegate void ShootingActions();
    public static event ShootingActions OnShootingActions;

    public PlayerShootingManager CurrentShootingManager
    {
        get
        {
            PlayerShootingSM.OnShootingAction -= PlayerBeginToShooting;
            return currentShootingManager;
        }
        set
        {
            if (value != null)
            {
                PlayerShootingSM.OnShootingAction += PlayerBeginToShooting;
                OnShootingActions?.Invoke();
            }
        }
    }
    public virtual PlayerShootingManager PlayerShooting
    {
        get
        {
            PlayerShootingSM.OnShootingAction -= PlayerEndToShooting;
            OnShootingActions?.Invoke();
            return null;
        }
        set
        {
            PlayerShootingSM.OnShootingAction += PlayerEndToShooting;
        }
    }
    void PlayerBeginToShooting()
    {
        PlayerShooting = CurrentShootingManager;
    }
    void PlayerEndToShooting()
    {
        currentShootingManager = PlayerShooting;
    }
    //void DisableShootingMode()
    //{
    //    currentShootingManager = CurrentShootingManager;
    //}
}
//get
//{
//    currentShootingManager.OnShooting += currentShootingManager.CalculateTimeForNextShot;
//    Firepoint.OnFirepointDisable -= DisableShootingMode;
//    return null;
//}
//set
//{
//    if (value != null)
//    {
//        value.OnShooting += value.CalculateTimeForNextShot;
//    }
//    Firepoint.OnFirepointDisable += DisableShootingMode;
//    currentShootingManager = value;
//}