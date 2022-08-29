using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpSM : PlayerShootAndMove
{
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        animator.SetBool("IsJumping", false);
    }

}
