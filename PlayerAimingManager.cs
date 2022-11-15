using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimingManager : FirepointTargetable
{
    public Camera cam;
    public Transform aimTransform;
    public float distanceToAim = 2f;
    FirepointAction<PlayerAimingManager> aimingDirection = new FirepointAction<PlayerAimingManager>();

    delegate void AimingAction(Transform firepointTransform);
    AimingAction OnAiming;
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
    PlayerAimingManager AimingEnabled
    {
        get
        {
            OnAiming = MoveAimToDistance;
            OnAiming += RotateFirepointEnable;
            return this;
        }
    }
    public override void EnableTargetableAction()
    {
        aimingDirection.CurrentFPTargetable = AimingEnabled;
    }
    public override void PlayerFPAction(Transform currentFirepoint)
    {
        OnAiming?.Invoke(currentFirepoint);
    }
    private void Update()
    {
        aimingDirection.ResolveFirepointAction();
    }
    void RotateFirepointEnable(Transform currentFirepoint)
    {
        Vector3 mouseDirection = ((Vector3)MousePosition - currentFirepoint.position).normalized;
        currentFirepoint.right = Mathf.Sign(mouseDirection.x) * PlayerLooksToRight * mouseDirection;
    }
    void MoveAimToDistance(Transform currentFirepoint)
    {
        OnAiming -= MoveAimToDistance;
        aimTransform.parent = currentFirepoint;
        Ray aimRay = new Ray(currentFirepoint.position, currentFirepoint.right);
        aimTransform.position = aimRay.GetPoint(distanceToAim);
        aimTransform.localEulerAngles = Vector3.zero;
    }
}
