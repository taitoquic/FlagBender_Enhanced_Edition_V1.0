using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirepointShooting 
{
    GameObject currentFirepoint;
    public GameObject CurrentFirepoint
    {
        get
        {
            PlayerMovementSM.OnMovementSMAction -= ExitCurrentFirepoint;
            ShootingAction.OnShootingActions -= TargetFirepointShooting;
            return currentFirepoint;
        }
        set
        {
            if (value != null)
            {
                value.SetActive(true);
                PlayerMovementSM.OnMovementSMAction += ExitCurrentFirepoint;
                ShootingAction.OnShootingActions += TargetFirepointShooting;
            }
            else
            {
                CurrentFirepoint.SetActive(false);
            }
            currentFirepoint = value;
        }
    }
    GameObject CurrentFirepointShooting
    {
        get
        {
            currentFirepoint.SetActive(false);
            ShootingMode.OnDisableFirepoint -= ExitCurrentFirepointShooting;
            return null;
        }
        set
        {
            ShootingMode.OnDisableFirepoint += ExitCurrentFirepointShooting;
        }
    }
    void ExitCurrentFirepoint()
    {
        CurrentFirepoint = null;
    }
    void TargetFirepointShooting()
    {
        CurrentFirepointShooting = CurrentFirepoint;
    }
    void ExitCurrentFirepointShooting()
    {
        currentFirepoint = CurrentFirepointShooting;
    }
}