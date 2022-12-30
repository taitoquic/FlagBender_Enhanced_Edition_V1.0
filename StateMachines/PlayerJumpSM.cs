using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpSM : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsJumping", false);
    }
    //Animator EndJump
    //{
    //    set
    //    {
    //        if(value != null)
    //        {
    //            value.SetBool("IsJumping", false);
    //        }
    //    }
    //}
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    base.OnStateExit(animator, stateInfo, layerIndex);
    //    EndJump = animator;
    //}
}
