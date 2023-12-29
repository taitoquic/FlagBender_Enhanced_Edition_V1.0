using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingChargableSM : StateMachineBehaviour
{
    public delegate void PlayerChargedActions();
    public static event PlayerChargedActions OnPlayerShootingChargable;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnPlayerShootingChargable?.Invoke();
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnPlayerShootingChargable?.Invoke();
    }
}
