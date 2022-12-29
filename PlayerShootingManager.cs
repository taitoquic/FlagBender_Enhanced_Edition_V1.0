using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingManager : FirepointTargetable
{
    public BulletTemplate currentBulletEquiped;
    float nextShotTime = 0f;
    FirepointAction shootingDirection = new FirepointAction();
    public override FirepointAction TargetableFirepointAction
    {
        get
        {
            return shootingDirection;
        }
    }
    public bool HasPassedNecessaryTimeForShot
    {
        get
        {
            return Time.time > nextShotTime;
        }
    }
    public override void FirepointAction(Transform firepointTransform)
    {
        Instantiate(currentBulletEquiped.bulletPrefab, firepointTransform.position, firepointTransform.rotation);
    }
    public void Shot()
    {
        shootingDirection.ResolveFirepointAction();
    }
    public void CalculateTimeForNextShot()
    {
        nextShotTime = Time.time + currentBulletEquiped.cadencyShot;
    }
}