using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpSM : PlayerOnAirSM
{
    public static event ActionInMovementState OnEnableAirFirepoint;
    public override Animator CurrentAnimator
    {
        set
        {
            OnEnableAirFirepoint?.Invoke(StateIndex);
            base.CurrentAnimator = value;
        }
    }
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CurrentAnimator = animator;
    }
}