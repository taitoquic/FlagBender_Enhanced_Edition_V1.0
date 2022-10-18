using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSM : StateMachineBehaviour
{
    Animator currentAnimator;

    public delegate void MovementActions();
    public static event MovementActions OnMovementSMAction;
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
                OnMovementSMAction?.Invoke();
                EnableShootingController();
            }
            currentAnimator = value;
        }
    }
    public virtual bool StayableShotAllow
    {
        get
        {
            return false;
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
    public void EnableShootingController()
    {
        GameManager.instance.sMShootingManager.CurrentSM = this;
    }
    public virtual void ShootingInstructions(PlayerShootingManager currentShootingManager)
    {
        currentShootingManager.CalculateTimeForNextShot();
    }
    public virtual void BeginShootingAnimation()
    {
        CurrentAnimator.SetTrigger("Shooting");
    }
}