using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnAirShootingSM : PlayerShootingInMovementSM
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("AirShot", true);
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("AirShot", false);
        base.OnStateExit(animator, stateInfo, layerIndex);
    }
}
