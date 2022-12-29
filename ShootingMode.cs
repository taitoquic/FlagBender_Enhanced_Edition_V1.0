using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class ShootingMode 
{
    PlayerShootingManager currentShootingManager;

    public delegate void DisableFirepoint();
    public static event DisableFirepoint OnDisableFirepoint;

    public PlayerShootingManager CurrentShootingManager
    {
        get
        {
            PlayerShootingSM.OnShootingAction -= PlayerFirstShot;
            return currentShootingManager;
        }
        set
        {
            if (value != null)
            {
                PlayerShootingSM.OnShootingAction += PlayerFirstShot;
            }
            currentShootingManager = value;
        }
    }
    public virtual PlayerShootingManager CurrentShootingModeFirstShot
    {
        get
        {
            OnDisableFirepoint?.Invoke();
            PlayerShootingSM.OnShootingAction -= ExitShooting;
            return null;
        }
        set
        {
            PlayerShootingSM.OnShootingAction += ExitShooting;
        }
    }
    void PlayerFirstShot()
    {
        CurrentShootingModeFirstShot = CurrentShootingManager;
    }
    void ExitShooting()
    {
        currentShootingManager = CurrentShootingModeFirstShot;
    }
}