using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirepointState 
{
    GameObject currentFirepoint;

    public delegate void FirepointAction();
    public static event FirepointAction OnFirepointDisable;
    GameObject ExitFirepoint
    {
        get
        {
            OnFirepointDisable?.Invoke();
            return null;
        }
    }

    public GameObject CurrentFirepoint
    {
        get
        {
            PlayerMovementSM.OnMovementSMAction -= ExitFirepointWithoutShooting;
            PlayerMovementSM.OnShooting -= TargetFirepointShooting;
            return currentFirepoint;
        }
        set
        {
            if (value != null)
            {
                PlayerMovementSM.OnMovementSMAction += ExitFirepointWithoutShooting;
                PlayerMovementSM.OnShooting += TargetFirepointShooting;
            }
            else
            {
                currentFirepoint = CurrentFirepoint;
            }
            currentFirepoint = value;
        }
    }
    public GameObject ShootingFirepoint
    {
        get
        {
            ShootingAction.OnDisableFirepoint -= DisableFirepointAtShooting;
            return ExitFirepoint;
        }
        set
        {
            ShootingAction.OnDisableFirepoint += DisableFirepointAtShooting;
        }
    }
    void ExitFirepointWithoutShooting()
    {
        CurrentFirepoint = ExitFirepoint;
    }
    void TargetFirepointShooting()
    {
        ShootingFirepoint = CurrentFirepoint;
    }
    void DisableFirepointAtShooting()
    {
        currentFirepoint = ShootingFirepoint;
    }
}