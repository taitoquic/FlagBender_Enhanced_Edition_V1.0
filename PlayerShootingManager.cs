using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingManager : FirepointTargetable
{
    public BulletTemplate currentBulletEquiped;
    float nextShotTime = 0f;
    public bool HasPassedNecessaryTimeForShot
    {
        get
        {
            return Time.time > nextShotTime;
        }
    }
    public override void ActionToInitialize()
    {
        Instantiate(currentBulletEquiped.bulletPrefab, FirepointTransform.position, FirepointTransform.rotation);
    }
    public void Shot()
    {
        OnFirepointAction.Invoke();
    }
    public void CalculateTimeForNextShot()
    {
        nextShotTime = Time.time + currentBulletEquiped.cadencyShot;
    }
}