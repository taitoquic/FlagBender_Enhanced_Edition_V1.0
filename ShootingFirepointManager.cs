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
            FirepointManager.EnableFirepointsManager(targetFirepointIndex);
            CurrentFirepointsManager = FirepointManager;
        }
    }
    public FirepointsManager CurrentFirepointsManager
    {
        get
        {
            PlayerMovementSM.OnMovementSMAction -= MoveToOtherMovementSM;
            //ShootingAction.OnShootingActions -= StopMovementForShooting;
            return currentFirepointsManager;
        }
        set
        {
            if (value != null)
            {
                PlayerMovementSM.OnMovementSMAction += MoveToOtherMovementSM;
                //ShootingAction.OnShootingActions += StopMovementForShooting;
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
            //ShootingTemplate.OnEndShooting -= MoveToOtherMovementSMAfterShooting;
            currentFirepointsManager.EnableFirepointsManager(targetFirepointIndex);
            return null;
        }
        set
        {
            //ShootingTemplate.OnEndShooting += MoveToOtherMovementSMAfterShooting;
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