using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerMovementAction_Aiming 
{
    public Transform aimTransform;
    public Camera cam;
    public float isPlayerFacingToRight = 1f;
    public float distanceToAim = 2f;

    Vector2 MousePosition
    {
        get
        {
            return cam.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    public Vector3 CalculateNewTransformRight(Transform targetTransform)
    {
        Vector3 mouseDirection = ((Vector3)MousePosition - targetTransform.position).normalized;
        return Mathf.Sign(mouseDirection.x) * isPlayerFacingToRight * mouseDirection;
    }

    public void MoveAimToDistance(Transform targetTransform)
    {
        Ray aimRay = new Ray(targetTransform.position, targetTransform.right);
        aimTransform.position = aimRay.GetPoint(distanceToAim);
    }
}
