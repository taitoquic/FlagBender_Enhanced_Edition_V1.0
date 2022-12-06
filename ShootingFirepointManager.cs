using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingFirepointManager 
{
    int targetFirepointIndex;
    FirepointsManager currentFirepointsManager;
    FirepointsManager FirepointManager
    {
        get
        {
            return GameManager.instance.firepointsManager;
        }
    }

    public int TargetFirepointIndex
    {
        set
        {
            targetFirepointIndex = value;
            CurrentFirepointsManager = FirepointManager;
        }
    }
    public FirepointsManager CurrentFirepointsManager
    {
        get
        {
            PlayerMovementSM.OnMovementSMAction -= MoveToOtherMovementSM;
            ShootingAction.OnShootingActions -= StopMovementForShooting;
            return currentFirepointsManager;
        }
        set
        {
            if (value != null)
            {
                value.EnableFirepointsManager(targetFirepointIndex);
                PlayerMovementSM.OnMovementSMAction += MoveToOtherMovementSM;
                ShootingAction.OnShootingActions += StopMovementForShooting;
            }
            else
            {
                CurrentFirepointsManager.EnableFirepointsManager(targetFirepointIndex);
            }
            currentFirepointsManager = value;
        }
    }
    FirepointsManager ShootingFirepointsManager
    {
        get
        {
            ShootingAction.OnShootingActions -= MoveToOtherMovementSMAfterShooting;
            currentFirepointsManager.EnableFirepointsManager(targetFirepointIndex);
            return null;
        }
        set
        {
            ShootingAction.OnShootingActions += MoveToOtherMovementSMAfterShooting;
        }
    }
    void MoveToOtherMovementSM()
    {
        CurrentFirepointsManager = null;
    }
    void StopMovementForShooting()
    {
        ShootingFirepointsManager = CurrentFirepointsManager;
    }
    void MoveToOtherMovementSMAfterShooting()
    {
        currentFirepointsManager = ShootingFirepointsManager;
    }
}