using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingInMovementSM : PlayerShootingSM
{
    Animator currentAnimator;
    Animator CurrentAnimator
    {
        set
        {
            currentAnimator = value;
            if(value != null)
            {
                PlayerShootingInMovement.OnAfterFirstShot += ResetShootingTrigger;
            }
            else
            {
                PlayerShootingInMovement.OnAfterFirstShot -= ResetShootingTrigger;
            }
        }
    }
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CurrentAnimator = animator;
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        CurrentAnimator = null;
    }
    void ResetShootingTrigger()
    {
        currentAnimator.ResetTrigger("Shooting");
    }
}
