using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingManager : MonoBehaviour
{
    public BulletTemplate currentBulletEquiped;
    float nextShotTime = 0f;

    public delegate void PlayerShoting(BulletTemplate currentBullet);
    public static event PlayerShoting OnPlayerShooting;
    public bool HasPassedNecessaryTimeForShot
    {
        get
        {
            return Time.time > nextShotTime;
        }
    }
    public void Shot()
    {
        OnPlayerShooting?.Invoke(currentBulletEquiped);
    }
    public void CalculateTimeForNextShot()
    {
        nextShotTime = Time.time + currentBulletEquiped.cadencyShot;
    }
}