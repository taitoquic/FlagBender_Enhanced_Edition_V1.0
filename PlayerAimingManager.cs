using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimingManager : FirepointTargetable
{
    public Camera cam;
    public Transform aimTransform;
    public float distanceToAim = 2f;
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
    Transform AimTransform
    {
        get
        {
            OnFirepointAction.RemoveListener(MoveAimToDistance);
            return aimTransform;
        }
        set
        {
            OnFirepointAction.AddListener(MoveAimToDistance);
        }
    }
    public override Transform FirepointTransform
    {
        set
        {
            base.FirepointTransform = value;
            AimTransform = aimTransform;
        }
    }
    private void Update()
    {
        OnFirepointAction.Invoke();
    }
    public override void ActionToInitialize()
    {
        Vector3 mouseDirection = ((Vector3)MousePosition - FirepointTransform.position).normalized;
        FirepointTransform.right = Mathf.Sign(mouseDirection.x) * PlayerLooksToRight * mouseDirection;
    }
    void MoveAimToDistance()
    {
        Ray aimRay = new Ray(FirepointTransform.position, FirepointTransform.right);
        AimTransform.parent = FirepointTransform;
        aimTransform.position = aimRay.GetPoint(distanceToAim);
        aimTransform.localEulerAngles = Vector3.zero;
    }
}