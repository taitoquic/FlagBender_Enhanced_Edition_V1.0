using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnAirSM : PlayerMovementSM
{
    public delegate void PlayerOnAirAnimation(Animator currentAnimator);
    public static event PlayerOnAirAnimation OnAirAnimation;
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
    Animator ShootingOnAirAnimator
    {
        get
        {
            CurrentAnimatorSM.SetBool("AirShot", false);
            return null;
        }
        set
        {
            CurrentAnimatorSM.SetBool("AirShot", true);
        }
    }
    public override void PlayerBeginShooting()
    {
        ShootingOnAirAnimator = CurrentAnimator;
        OnMovementSMAction = null;
    }
    public override void PlayerEndShooting()
    {
        if(OnMovementSMAction==null) CurrentAnimatorSM = ShootingOnAirAnimator;
        base.PlayerEndShooting();
    }
}