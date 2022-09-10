using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingManager : MonoBehaviour
{
    public Transform[] firepoints = new Transform[3];
    public PlayerMovementAction_Aiming aiming;
    public PlayerMovementAction_Shooting shooting;

    public delegate void PlayerInteractTransform(Transform[] firepoints, PlayerMovementAction_Aiming aiming);
    public static event PlayerInteractTransform OnAimMouseDirection;

    public delegate void PlayerInteractTransformToShoot(Transform[] firepoints, PlayerMovementAction_Shooting shooting);
    public static event PlayerInteractTransformToShoot OnPlayerShooting;
    float IsPlayerFacingToRight
    {
        get
        {
            return Mathf.Sign(transform.rotation.y);
        }
    }
    GameObject BulletPrefab
    {
        get
        {
            return shooting.bulletPrefab;
        }
    }

    private void Update()
    {
        aiming.isPlayerFacingToRight = IsPlayerFacingToRight;
        OnAimMouseDirection?.Invoke(firepoints, aiming);
    }
    public void Shot()
    {
        OnPlayerShooting?.Invoke(firepoints, shooting);
    }
    public void ActivateFirepoint(int stateIndex)
    {
        firepoints[stateIndex].gameObject.SetActive(true);
    }
    public void DesactivateFirepoint(int stateIndex)
    {
        firepoints[stateIndex].gameObject.SetActive(false);
    }
    void StandShot()
    {
        Instantiate(BulletPrefab, firepoints[0].position, firepoints[0].rotation);
    }
}