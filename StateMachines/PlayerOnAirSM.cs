using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerOnAirSM : PlayerMovementSM
{
    Animator airShootingAnimator;
    public override int StateIndex
    {
        get
        {
            return 2;
        }
    }
    ShootingActionStayable ShootingModeStayable
    {
        get
        {
            return (ShootingActionStayable)ShootingModeStandard;
        }
    }
    Animator AirShootingAnimator
    {
        get
        {
            airShootingAnimator.SetBool("AirShooting", false);
            ShootingAction.OnDisableFirepoint -= RemoveAirShootingAnimator;
            return null;
        }
        set
        {
            if (value != null)
            {
                value.SetBool("AirShooting", true);
                ShootingAction.OnDisableFirepoint += RemoveAirShootingAnimator;
            }
            airShootingAnimator = value;
        }
    }
    public override Animator ShootingAnimator
    {
        set
        {
            AirShootingAnimator = value;
            base.ShootingAnimator = value;
        }
    }
    public override void PlayerBeginToShooting(PlayerShootingManager playerShootingManager)
    {
        ShootingModeStayable.CurrentShootingManager = playerShootingManager;
    }
    void RemoveAirShootingAnimator()
    {
        airShootingAnimator = AirShootingAnimator;
    }
}