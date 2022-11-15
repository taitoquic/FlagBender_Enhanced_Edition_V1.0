using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingManager : FirepointTargetable
{
    public BulletTemplate currentBulletEquiped;
    float nextShotTime = 0f;
    FirepointAction<PlayerShootingManager> shootingDirection = new FirepointAction<PlayerShootingManager>();
    PlayerMovementSM currentPlayerShooting;
    public bool HasPassedNecessaryTimeForShot
    {
        get
        {
            return Time.time > nextShotTime;
        }
    }
    public PlayerShootingManager TriggerOn
    {
        get
        {
            nextShotTime = Time.time + currentBulletEquiped.cadencyShot;
            return this;
        }
    }
    bool ShootingAfterFirstShotAllowed
    {
        get
        {
            return currentPlayerShooting != null;
        }
    }

    public PlayerMovementSM CurrentPlayerShooting
    {
        get
        {
            PlayerShootingSM.OnShootingAction -= FirstShot;
            return currentPlayerShooting;
        }
        set
        {
            if(value != null)
            {
                value.ChangeAnimatorToShootingSM();
            }
            PlayerShootingSM.OnShootingAction += FirstShot;
            currentPlayerShooting = value;
        }
    }
    bool StayableMode
    {
        get
        {
            PlayerShootingSM.OnShootingAction -= EndShooting;
            return ShootingAfterFirstShotAllowed;
        }
        set
        {
            if (value)
            {
                Shot();
            }
            else
            {
                currentPlayerShooting = null;
            }
            PlayerShootingSM.OnShootingAction += EndShooting;
        }
    }
    public override void EnableTargetableAction()
    {
        shootingDirection.CurrentFPTargetable = this;
    }
    public override void PlayerFPAction(Transform currentFirepoint)
    {
        Instantiate(currentBulletEquiped.bulletPrefab, currentFirepoint.position, currentFirepoint.rotation);
    }
    public void Shot()
    {
        shootingDirection.ResolveFirepointAction();
    }
    void FirstShot()
    {
        StayableMode = CurrentPlayerShooting.CurrentAnimatorSM != null;
    }
    void EndShooting()
    {
        if (StayableMode)
        {
            currentPlayerShooting.PlayerEndShooting();
            currentPlayerShooting = null;
        }
    }
}