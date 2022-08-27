using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerShootingSM : StateMachineBehaviour
{
    public abstract int ShootingStateIndex { get; }

    public delegate void StateAction(int stateIndex);
    public static event StateAction OnStateAction;

    public delegate void PlayerShotAction();
    public static event PlayerShotAction OnShotAction;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnShotAction?.Invoke();
        OnStateAction?.Invoke(ShootingStateIndex);
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnShotAction?.Invoke();
    }
}
