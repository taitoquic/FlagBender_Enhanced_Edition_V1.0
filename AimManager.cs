using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimManager : MonoBehaviour
{
    public Transform[] firepoints = new Transform[3];
    public Transform aimTransform;
    public Camera cam;
    public float distanceToAim = 2f;

    public delegate void AimMovement(Transform[] firepoints, Camera cam, Transform aimTransform, float aimDistance, float playerLookMouse);
    public static event AimMovement OnPlayerAim;

    float IsPlayerFacingToRight
    {
        get
        {
            return Mathf.Sign(transform.rotation.y);
        }
    }
    float IsMouseRightOfPlayer
    {
        get
        {
            return Mathf.Sign(cam.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x);
        }
    }
    float IsPlayerLookToMouse
    {
        get
        {
            return IsPlayerFacingToRight * IsMouseRightOfPlayer;
        }
    }

    void Update()
    {
        OnPlayerAim?.Invoke(firepoints, cam, aimTransform, distanceToAim, IsPlayerLookToMouse);
    }
}
