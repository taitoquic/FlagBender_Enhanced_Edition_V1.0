using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSM : StateMachineBehaviour
{
    Animator currentAnimatorSM;
    public int stateIndex = 0;

    public delegate void MovementActions();
    public static event MovementActions OnMovementSMAction;

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
    int StateIndex
    {
        get
        {
            OnMovementSMAction = ChangeSMWithoutShooting;
            return stateIndex;
        }
    }
    FirepointsManager FirepointManager
    {
        get
        {
            return GameManager.instance.firepointsManager;
        }
    }
    PlayerMovementSM PlayerShootingInMovement
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
            if (value != null)
            {
                FirepointManager.EnableFirepointsManager(StateIndex);
                PlayerMovement.OnPlayerPressFireButton += ShootingInstructions;
                currentAnimatorSM = value;
            }
        }
    }
    public virtual Animator ShootingAnimator
    {
        get
        {
            return null;
        }
        set
        {
            PlayerEndShooting();
            currentAnimatorSM = value;
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
    void ChangeSMWithoutShooting()
    {
        currentAnimatorSM = CurrentAnimator;
    }
    void ShootingInstructions(PlayerShootingManager currentShootingManager)
    {
        currentShootingManager.CurrentPlayerShooting = PlayerShootingInMovement;
    }
    void PlayerBeginShooting()
    {
        ShootingAnimator = CurrentAnimator;
        OnMovementSMAction = null;
    }
    public virtual void PlayerEndShooting()
    {
        currentAnimatorSM = ShootingAnimator;
    }
    public virtual void ChangeAnimatorToShootingSM()
    {
        currentAnimatorSM.SetTrigger("Shooting");
    }
}