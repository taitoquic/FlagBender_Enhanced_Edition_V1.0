using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStandSM : PlayerMovementSM
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        PlayerFeatures.playerShootingStand.OnEnterShootingState();
    }
}
