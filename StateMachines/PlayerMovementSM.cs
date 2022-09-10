using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMovementSM : StateMachineBehaviour, IAimingSMInteractable
{
    public int stateIndex;
    static int oldStateIndex;

    public int OldStateIndex
    {
        get
        {
            return oldStateIndex;
        }
        set
        {
            oldStateIndex = value;
        }
    }
    public int InteractableStateIndex
    {
        get
        {
            return stateIndex;
        }
    }
    public Features PlayerFeatures
    {
        get
        {
            return GameManager.instance.features;
        }
    }

    public delegate void MovementStateAction();
    public static event MovementStateAction OnMovementStateAction;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnMovementStateAction?.Invoke();
        PlayerFeatures.playerAiming.CurrentAimable = this;
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerFeatures.playerAiming.OnAimableStateExit();
    }
}
