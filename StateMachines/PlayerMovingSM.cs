using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingSM : PlayerMovementSM, IShootingAndMoveSMInteractable
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        PlayerFeatures.playerShootingInMovement.CurrentState = this;
    }
}
