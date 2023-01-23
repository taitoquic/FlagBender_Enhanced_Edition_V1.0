using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FirepointActivableSM : StateMachineBehaviour
{
    public abstract int StateIndex { get; }

    public delegate void ActionInMovementState(int stateIndex);
    public static event ActionInMovementState OnEnableFirepoint;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnEnableFirepoint?.Invoke(StateIndex);
    }
}