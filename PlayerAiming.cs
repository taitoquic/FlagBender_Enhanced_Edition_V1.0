using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAiming : MonoBehaviour
{
    public delegate void AimingAction();
    public static AimingAction OnNewMovementState;

    public UnityEvent<int> OnTargetFirepointActive;
    public UnityEvent<int> OnTargetFirepointDesactive;

    int SetOldIndex
    {
        set
        {
            OnTargetFirepointDesactive.Invoke(currentAimable.OldStateIndex);
            OnTargetFirepointActive.Invoke(value);
            currentAimable.OldStateIndex = value;
        }
    }

    IAimingSMInteractable currentAimable;
    public IAimingSMInteractable CurrentAimable
    {
        set
        {
            currentAimable = value;
            if (value != null) 
            {
                PlayerShootingManager.OnAimMouseDirection += AimingInState;
                SetOldIndex = currentAimable.InteractableStateIndex;
            }
            else
            {
                PlayerShootingManager.OnAimMouseDirection -= AimingInState;
            }
        }
    }
    public void OnAimableStateExit()
    {
        PlayerMovementSM.OnMovementStateAction += StopAimingInState;
    }

    void AimingInState(Transform[] firepoints, PlayerMovementAction_Aiming aiming)
    {
        firepoints[currentAimable.InteractableStateIndex].right = aiming.CalculateNewTransformRight(firepoints[currentAimable.InteractableStateIndex]);
        aiming.MoveAimToDistance(firepoints[currentAimable.InteractableStateIndex]);
    }
    void StopAimingInState()
    {
        OnNewMovementState?.Invoke();
        PlayerMovementSM.OnMovementStateAction -= StopAimingInState;
        CurrentAimable = null;
    }
}