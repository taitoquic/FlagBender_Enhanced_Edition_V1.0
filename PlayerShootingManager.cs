using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShootingManager : FirepointTargetable
{
    public BulletTemplate currentBulletEquiped;
    public UnityEvent OnStopPlayerAtBeginShot;
    public UnityEvent OnResumeMovementAtEndShot;
    public UnityEvent OnShootingChargable;
    float nextShotTime = 0f;
    public bool HasPassedNecessaryTimeForShot
    {
        get
        {
            return Time.time > nextShotTime;
        }
    }
    public BulletTemplate CurrentBulletEquiped
    {
        set
        {
            if (value)
            {
                value.ActionsToEquip();
            }
            currentBulletEquiped = value;
        }
    }
    private void Start()
    {
        CurrentBulletEquiped = currentBulletEquiped;
    }
    public override void ActionToInitialize()
    {
        Instantiate(currentBulletEquiped.bulletPrefab, FirepointTransform.position, FirepointTransform.rotation);
    }
    public void Shot()
    {
        OnFirepointAction.Invoke();
    }
    public void ShootingCustomGameObject(GameObject customObject)
    {
        Instantiate(customObject, FirepointTransform.position, FirepointTransform.rotation);
    }
    public void CalculateTimeForNextShot()
    {
        nextShotTime = Time.time + currentBulletEquiped.cadencyShot;
    }
    public void ShootingChargable()
    {
        OnShootingChargable?.Invoke();
    }
}