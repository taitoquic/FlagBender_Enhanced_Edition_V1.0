using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSM : StateMachineBehaviour
{
    public delegate void MovementStateAction();
    public static event MovementStateAction OnMovementStateAction;
    public static event MovementStateAction OnNewMovementState;
    public int movementStateIndex = 0;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnMovementStateAction?.Invoke();
        AimManager.OnPlayerAim += AimingInState;
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnMovementStateAction?.Invoke();
        OnMovementStateAction += StopAimingInState;
    }

    public void AimingInState(Transform[] firepoints, Camera cam, Transform aimTransform, float aimDistance, float playerLookMouse)
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 mouseDirection = playerLookMouse * (mousePosition - firepoints[movementStateIndex].position).normalized;
        Ray aimRay = new Ray(firepoints[movementStateIndex].position, mouseDirection);
        aimTransform.position = aimRay.GetPoint(aimDistance);
        firepoints[movementStateIndex].right = (aimTransform.position - firepoints[movementStateIndex].position).normalized;
    }
    public void StopAimingInState()
    {
        OnNewMovementState?.Invoke();
        AimManager.OnPlayerAim -= AimingInState;
        OnMovementStateAction -= StopAimingInState;
    }
}
