using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSM : StateMachineBehaviour
{
    Animator currentAnimatorSM;
    public int stateIndex = 0;

    public delegate void MovementActions();
    public MovementActions OnMovementSMAction;

    public Animator CurrentAnimatorSM
    {
        get
        {
            return currentAnimatorSM;
        }
        set
        {
            currentAnimatorSM = value;
        }
    }
    FirepointsManager FirepointManager
    {
        get
        {
            return GameManager.instance.firepointsManager;
        }
    }
    public virtual PlayerMovementSM PlayerShootingInMovement
    {
        get
        {
            OnMovementSMAction = PlayerBeginShooting;
            return this;
        }
    }
    public virtual Animator CurrentAnimator
    {
        get
        {
            PlayerMovement.OnPlayerPressFireButton -= ShootingInstructions;
            return null;
        }
        set
        {
            FirepointManager.EnableFirepointsManager(stateIndex);
            if (value != null)
            {
                OnMovementSMAction = PlayerEndShooting;
                PlayerMovement.OnPlayerPressFireButton += ShootingInstructions;
                currentAnimatorSM = value;
            }
            else if (currentAnimatorSM != null)
            {
                currentAnimatorSM = CurrentAnimator;
                OnMovementSMAction -= PlayerEndShooting;
            }
        }
    }
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CurrentAnimator = animator;
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnMovementSMAction?.Invoke();
    }
    void ShootingInstructions(PlayerShootingManager currentShootingManager)
    {
        currentShootingManager.CurrentPlayerShooting = PlayerShootingInMovement;
    }
    public virtual void PlayerBeginShooting()
    {
        currentAnimatorSM = CurrentAnimator;
        OnMovementSMAction = null;
    }
    public virtual void PlayerEndShooting()
    {
        CurrentAnimator = null;
    }
    public void ChangeAnimatorToShootingSM()
    {
        currentAnimatorSM.SetTrigger("Shooting");
    }
}