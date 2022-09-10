using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpSM : PlayerMovingSM
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsJumping", false);
        base.OnStateExit(animator, stateInfo, layerIndex);
    }
}
