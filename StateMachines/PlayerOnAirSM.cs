using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnAirSM : PlayerMovementSM
{
    Animator OnAirAnimator
    {
        set
        {
            BeginShootingAnimation.CurrentAnimator = value;
            if (value != null)
            {
                value.SetBool("IsOnAir", true);
            }
        }
    }
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnAirAnimator = animator;
    }
    //public delegate void PlayerOnAirAnimation(Animator currentAnimator);
    //public static event PlayerOnAirAnimation OnAirAnimation;
    //public override Animator CurrentAnimator
    //{
    //    get
    //    {
    //        return base.CurrentAnimator;
    //    }
    //    set
    //    {
    //        if(value != null)
    //        {
    //            OnAirAnimation?.Invoke(value);
    //        }
    //        base.CurrentAnimator = value;

    //    }
    //}
}