using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSM : StateMachineBehaviour
{
    public int stateIndex;
    ShootingAnimation shootingAnimation = new ShootingAnimation();
    ShootingFirepointManager shootingFirepointManager = new ShootingFirepointManager();

    public delegate void MovementAction();
    public static event MovementAction OnMovementSMAction;
    ShootingAnimation BeginShootingAnimation
    {
        get
        {
            shootingFirepointManager.TargetFirepointIndex = stateIndex;
            return shootingAnimation;
        }
    }
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        BeginShootingAnimation.CurrentAnimator = animator;
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnMovementSMAction?.Invoke();
    }
}