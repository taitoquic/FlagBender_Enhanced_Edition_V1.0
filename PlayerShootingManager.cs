using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingManager : FirepointTargetable
{
    public BulletTemplate currentBulletEquiped;
    float nextShotTime = 0f;
    FirepointAction shootingDirection = new FirepointAction();

    public delegate void ShootingMode();
    public ShootingMode OnShooting;

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
    public bool IsShootingInAnimation
    {
        get
        {
            PlayerShootingSM.OnShootingAction -= TriggerOn;
            return shootingDirection.CurrentFirepointIndex == 0;
        }
        set
        {
            if (!value)
            {
                OnShooting += Shot;
            }
            OnShooting += CalculateTimeForNextShot;
            PlayerShootingSM.OnShootingAction += TriggerOn;
        }
    }
    public override void FirepointAction(Transform firepointTransform)
    {
        Instantiate(currentBulletEquiped.bulletPrefab, firepointTransform.position, firepointTransform.rotation);
    }
    public void FirstShot()
    {
        IsShootingInAnimation = shootingDirection.CurrentFirepointIndex == 0;
    }
    public void TriggerOn()
    {
        OnShooting?.Invoke();
    }
    public void Shot()
    {
        shootingDirection.ResolveFirepointAction();
    }
    void CalculateTimeForNextShot()
    {
        nextShotTime = Time.time + currentBulletEquiped.cadencyShot;
    }
}