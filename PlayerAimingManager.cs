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
    public override Transform CurrentFirepointTransform
    {
        set
        {
            if (value != null)
            {
                aimingDirection.OnFirepointActionValid += MoveAimToDistance;
            }
            base.CurrentFirepointTransform = value;
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
    float DistanceToAim
    {
        get
        {
            aimingDirection.OnFirepointActionValid -= MoveAimToDistance;
            return distanceToAim;
        }
    }
    private void Update()
    {
        aimingDirection.ResolveFirepointAction();
    }
    void MoveAimToDistance(Transform currentFirepoint)
    {
        Ray aimRay = new Ray(currentFirepoint.position, currentFirepoint.right);
        aimTransform.parent = currentFirepoint;
        aimTransform.position = aimRay.GetPoint(DistanceToAim);
        aimTransform.localEulerAngles = Vector3.zero;
    }
    public override void FirepointAction(Transform firepointTransform)
    {
        Vector3 mouseDirection = ((Vector3)MousePosition - firepointTransform.position).normalized;
        firepointTransform.right = Mathf.Sign(mouseDirection.x) * PlayerLooksToRight * mouseDirection;
    }
}
