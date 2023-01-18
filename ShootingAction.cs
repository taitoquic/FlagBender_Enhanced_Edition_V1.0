using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootingAction 
{
    PlayerShootingManager playerFirstShot;

    public delegate void DisableFirepoint();
    public static event DisableFirepoint OnDisableFirepoint;

    PlayerShootingManager PlayerLastShot
    {
        get
        {
            OnDisableFirepoint?.Invoke();
            return null;
        }
    }

    public virtual PlayerShootingManager PlayerFirstShot
    {
        get
        {
            PlayerShootingSM.OnShootingAction -= FirstShot;
            return playerFirstShot;
        }
        set
        {
            PlayerShootingSM.OnShootingAction += FirstShot;
            playerFirstShot = value;
        }
    }
    public virtual PlayerShootingManager PlayerAfterFirstShot
    {
        get
        {
            PlayerShootingSM.OnShootingAction -= AfterFirstShot;
            return PlayerLastShot;
        }
        set
        {
            PlayerShootingSM.OnShootingAction += AfterFirstShot;
        }
    }
    void FirstShot()
    {
        PlayerAfterFirstShot = PlayerFirstShot;
    }
    void AfterFirstShot()
    {
        playerFirstShot = PlayerAfterFirstShot;
    }
}