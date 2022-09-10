using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingSM : StateMachineBehaviour
{
    public delegate void PlayerShotAction();
    public static event PlayerShotAction OnEndShotAction;
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnEndShotAction?.Invoke();
    }
}