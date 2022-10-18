using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMShootingManager:MonoBehaviour
{
    public SMShootingFeature sMCurrentShootingFeature;
    PlayerMovementSM currentSM;

    SMShootingFeature SMCurrentShootingFeature
    {
        get
        {
            PlayerMovementSM.OnMovementSMAction += ExitMovementState;
            PlayerMovement.OnPlayerPressFireButton += sMCurrentShootingFeature.MovementSMShooting;
            return sMCurrentShootingFeature;
        }
    }
    public PlayerMovementSM CurrentSM
    {
        get
        {
            PlayerMovementSM.OnMovementSMAction -= ExitMovementState;
            PlayerMovement.OnPlayerPressFireButton -= sMCurrentShootingFeature.MovementSMShooting;
            return currentSM;
        }
        set
        {
            if(value != null)
            {
                SMShootingFeature.OnShootingInstructions += value.ShootingInstructions;
                SMCurrentShootingFeature.OnCurrentSMAction = PlayerBeginShooting;
            }
            else
            {
                SMShootingFeature.OnShootingInstructions -= CurrentSM.ShootingInstructions;
                sMCurrentShootingFeature.OnCurrentSMAction = null;
            }
            currentSM = value;
        }
    }
    PlayerMovementSM CurrentSMShooting
    {
        get
        {
            SMShootingFeature.OnShootingInstructions -= currentSM.ShootingInstructions;
            PlayerShootingSM.OnShootingAction -= FirstShotActions;
            PlayerShootingSM.OnShootingAction += ExitMovementState;
            return currentSM;
        }
        set
        {
            PlayerShootingSM.OnShootingAction += FirstShotActions;
            value.BeginShootingAnimation();
        }
    }
    void PlayerBeginShooting()
    {
        CurrentSMShooting = CurrentSM;
        sMCurrentShootingFeature.OnCurrentSMAction = ContinueShootingInMovement;
    }
    void FirstShotActions()
    {
        sMCurrentShootingFeature.ShootingAfterFirstShot = CurrentSMShooting.StayableShotAllow;

    }
    void ContinueShootingInMovement()
    {
        PlayerMovement.OnPlayerPressFireButton += currentSM.ShootingInstructions;
        sMCurrentShootingFeature.OnCurrentSMAction = null;
    }
    void ExitMovementState()
    {
        if (!sMCurrentShootingFeature.FirstShotDone)
        {
            CurrentSM = null;
        }
        else if(!sMCurrentShootingFeature.ShootingAfterFirstShot)
        {
            PlayerShootingSM.OnShootingAction -= ExitMovementState;
        }
        else
        {
            PlayerMovement.OnPlayerPressFireButton -= currentSM.ShootingInstructions;
            PlayerShootingSM.OnShootingAction -= ExitMovementState;
        }
        currentSM = null;
    }
}