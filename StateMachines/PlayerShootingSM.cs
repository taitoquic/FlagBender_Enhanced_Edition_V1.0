using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingSM : StateMachineBehaviour
{
    Animator currentAnimator;

    public delegate void PlayerShotAction();
    public static event PlayerShotAction OnShootingAction;

    public delegate void ShootingAnimation(Animator currentAnimator);
    public static event ShootingAnimation OnShootingAnimation;

    public virtual Animator CurrentAnimator
    {
        get
        {
            return currentAnimator;
        }
        set
        {
            if(value != null)
            {
                OnShootingAnimation?.Invoke(value);
            }
            else
            {
                OnShootingAnimation?.Invoke(currentAnimator);
            }
            OnShootingAction?.Invoke();
            currentAnimator = value;
        }
    }
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CurrentAnimator = animator;
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CurrentAnimator = null;
    }
}