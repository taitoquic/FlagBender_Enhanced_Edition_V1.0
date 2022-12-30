using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimingManager : FirepointTargetable
{
    public Camera cam;
    public Transform aimTransform;
    public float distanceToAim = 2f;
    FirepointAction aimingDirection = new FirepointAction();
    public override FirepointAction TargetableFirepointAction
    {
        get
        {
            return aimingDirection;
        }
    }
    Vector2 MousePosition
    {
        get
        {
            return cam.ScreenToWorldPoint(Input.mousePosition);
        }
    }
    float PlayerLooksToRight
    {
        get
        {
            return Mathf.Sign(transform.rotation.y);
        }
    }
    private void Update()
    {
        aimingDirection.ResolveFirepointAction();
    }
    public override void SetFirepointTransform(Transform firepointTransform)
    {
        base.SetFirepointTransform(firepointTransform);
        aimingDirection.OnFirepointActionValid += MoveAimToDistance;
    }
    void MoveAimToDistance(Transform currentFirepoint)
    {
        aimingDirection.OnFirepointActionValid -= MoveAimToDistance;
        Ray aimRay = new Ray(currentFirepoint.position, currentFirepoint.right);
        aimTransform.parent = currentFirepoint;
        aimTransform.position = aimRay.GetPoint(distanceToAim);
        aimTransform.localEulerAngles = Vector3.zero;
    }
    public override void FirepointAction(Transform firepointTransform)
    {
        Vector3 mouseDirection = ((Vector3)MousePosition - firepointTransform.position).normalized;
        firepointTransform.right = Mathf.Sign(mouseDirection.x) * PlayerLooksToRight * mouseDirection;
    }
}
