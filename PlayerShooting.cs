using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform[] firepoints = new Transform[3];
    public GameObject bulletPrefab;
    public float cadencyShot = 0.4f;
    float nextShotTime = 0f;
    public int amountShotsBeforeMovement = 0;

    public delegate void OnPlayerShooting(GameObject bulletPrefab, Transform[] firepoints);
    public static event OnPlayerShooting OnTriggerInMovement;

    public bool IsWeaponReloaded
    {
        get
        {
            return Time.time > nextShotTime;
        }
    }
    public bool IsShootingInSameMovement
    {
        get
        {
            return amountShotsBeforeMovement > 0;
        }
    }
    public int AmountShotsBeforeMovement
    {
        get
        {
            return amountShotsBeforeMovement;
        }
        set
        {
            if (value == 1)
            {
                PlayerMovementSM.OnNewMovementState += ResetShotsAmount;
            }
            amountShotsBeforeMovement = value;
        }
    }

    public void Shoot()
    {
        nextShotTime = Time.time + cadencyShot;
        OnTriggerInMovement?.Invoke(bulletPrefab, firepoints);
        AmountShotsBeforeMovement++;
    }
    void StandShot()
    {
        Instantiate(bulletPrefab, firepoints[0].position, firepoints[0].rotation);
    }
    void ResetShotsAmount()
    {
        AmountShotsBeforeMovement = 0;
        PlayerMovementSM.OnNewMovementState -= ResetShotsAmount;
    }
}