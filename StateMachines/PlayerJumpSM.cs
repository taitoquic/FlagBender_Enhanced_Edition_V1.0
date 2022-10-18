using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpSM : PlayerOnAirSM
{
    Animator EndJump
    {
        set
        {
            if(value != null)
            {
                value.SetBool("IsJumping", false);
            }
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        EndJump = animator;
    }
}
