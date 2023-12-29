using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChargedSM : StateMachineBehaviour
{
    Animator PlayerCharged
    {
        set
        {
            GameManager.instance.chargableFeature.CurrentAnimator = value;
        }
    }
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerCharged = animator;
    }
}
