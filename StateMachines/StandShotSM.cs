using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandShotSM : PlayerShootingSM
{
    public override int ShootingStateIndex
    {
        get
        {
            return 0;
        }
    }
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}

    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}
}
