using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    public ActionAiming aiming;

    public delegate void PlayerDoAction(ActionAiming aiming);
    public static event PlayerDoAction OnPlayerAiming;

    float IsPlayerFacingToRight
    {
        get
        {
            return Mathf.Sign(transform.rotation.y);
        }
    }

    private void Update()
    {
        aiming.isPlayerFacingToRight = IsPlayerFacingToRight;
        OnPlayerAiming?.Invoke(aiming);
    }
}