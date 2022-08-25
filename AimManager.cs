using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimManager : MonoBehaviour
{
    public Transform[] firepoints = new Transform[3];
    public Transform aimTransform;
    public Camera cam;
    public float distanceToAim = 5f;

    bool IsPlayerFacingToRight
    {
        get
        {
            return Mathf.Sign(transform.rotation.y) == 1;
        }
    }
    bool IsMouseRightOfPlayer
    {
        get
        {
            return Mathf.Sign(cam.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x) == 1;
        }
    }
    bool IsPlayerLookToMouse
    {
        get
        {
            return IsPlayerFacingToRight == IsMouseRightOfPlayer;
        }
    }

    void Update()
    {
        Debug.Log(IsPlayerLookToMouse);
    }
}
