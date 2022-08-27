using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMovementSM : StateMachineBehaviour
{
    public delegate void MovementStateAction();
    public static event MovementStateAction OnMovementStateAction;
    public abstract int MovementStateIndex { get; }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnMovementStateAction?.Invoke();
        AimManager.OnPlayerAim += AimingInState;
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnMovementStateAction += StopAimingInState;
    }

    public void AimingInState(Transform[] firepoints, Camera cam, Transform aimTransform, float aimDistance, float playerLookMouse)
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 mouseDirection = playerLookMouse * (mousePosition - firepoints[MovementStateIndex].position).normalized;
        Ray aimRay = new Ray(firepoints[MovementStateIndex].position, mouseDirection);
        aimTransform.position = aimRay.GetPoint(aimDistance);
        firepoints[MovementStateIndex].right = (aimTransform.position - firepoints[MovementStateIndex].position).normalized;
    }
    public void StopAimingInState()
    {
        AimManager.OnPlayerAim -= AimingInState;
        OnMovementStateAction -= StopAimingInState;
    }
}
