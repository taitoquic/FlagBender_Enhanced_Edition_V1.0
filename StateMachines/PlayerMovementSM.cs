using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSM : FirepointActivableSM
{
    Animator currentAnimator;

    public delegate void MovementAction();
    public static event MovementAction OnMovementSMAction;
    public static event MovementAction OnShooting;

    public override int StateIndex
    {
        get
        {
            return 0;
        }
    }
    public ShootingAction ShootingModeStandard
    {
        get
        {
            ShootingAnimator = CurrentAnimator;
            return GameManager.instance.PlayerShootingMode;
        }
    }
    string ShootingTrigger
    {
        get
        {
            OnShooting?.Invoke();
            return "Shooting";
        }
    }
    public virtual Animator CurrentAnimator
    {
        get
        {
            OnMovementSMAction -= ChangeSMWithoutShooting;
            PlayerMovement.OnPlayerPressFireButton -= PlayerBeginToShooting;
            return currentAnimator;
        }
        set
        {
            if (value != null)
            {
                OnMovementSMAction += ChangeSMWithoutShooting;
                PlayerMovement.OnPlayerPressFireButton += PlayerBeginToShooting;
            }
            else
            {
                currentAnimator = CurrentAnimator;
            }
            currentAnimator = value;
        }
    }
    public virtual Animator ShootingAnimator
    {
        get
        {
            OnMovementSMAction -= EndShootingAnimation;
            return null;
        }
        set
        {
            if (value != null)
            {
                value.SetTrigger(ShootingTrigger);
                OnMovementSMAction += EndShootingAnimation;
            }
        }
    }
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        CurrentAnimator = animator;
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnMovementSMAction?.Invoke();
    }
    void ChangeSMWithoutShooting()
    {
        CurrentAnimator = null;
    }
    public virtual void PlayerBeginToShooting(PlayerShootingManager playerShootingManager)
    {
        ShootingModeStandard.CurrentShootingManager = playerShootingManager;
    }
    void EndShootingAnimation()
    {
        currentAnimator = ShootingAnimator;
    }
}