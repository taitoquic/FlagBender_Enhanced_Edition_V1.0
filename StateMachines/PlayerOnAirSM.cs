using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnAirSM : PlayerMovementSM
{
    public override Animator CurrentAnimator
    {
        get
        {
            return base.CurrentAnimator;
        }
        set
        {
            if(value != null)
            {
                OnAirAnimation?.Invoke(value);
            }
            base.CurrentAnimator = value;

        }
    }
    public override bool StayableShotAllow
    {
        get
        {
            PlayerShootingSM.OnShootingAnimation += EndOnAirShotAnimation;
            return true;
        }
    }

    public delegate void PlayerOnAirAnimation(Animator currentAnimator);
    public static event PlayerOnAirAnimation OnAirAnimation;
    public override void ShootingInstructions(PlayerShootingManager currentShootingManager)
    {
        currentShootingManager.Shot();
        base.ShootingInstructions(currentShootingManager);
    }
    public override void BeginShootingAnimation()
    {
        CurrentAnimator.SetBool("AirShot", true);
    }
    void EndOnAirShotAnimation(Animator targetAnimator)
    {
        targetAnimator.SetBool("AirShot", false);
        PlayerShootingSM.OnShootingAnimation -= EndOnAirShotAnimation;
    }
}