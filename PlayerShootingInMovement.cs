using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingInMovement : PlayerShootingStand
{
    IShootingAndMoveSMInteractable currentState;

    public delegate void ShootingInMovementAction();
    public static event ShootingInMovementAction OnAfterFirstShot;

    public IShootingAndMoveSMInteractable CurrentState
    {
        set
        {
            currentState = value;
            if (value != null) 
            {
                OnEnterShootingState();
            }
        }
    }
    public override void ShootingInState(Transform[] firepoints, PlayerMovementAction_Shooting shooting)
    {
        OnAfterFirstShot?.Invoke();
        Instantiate(shooting.bulletPrefab, firepoints[currentState.InteractableStateIndex].position, firepoints[currentState.InteractableStateIndex].rotation);
        base.ShootingInState(firepoints, shooting);
    }
    public override void RemoveShotingInState()
    {
        base.RemoveShotingInState();
        CurrentState = null;
    }
}