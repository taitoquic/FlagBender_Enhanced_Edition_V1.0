using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingManager : FirepointTargetable
{
    public BulletTemplate currentBulletEquiped;
    public ShootingInMovementAction<PlayerMovementSM> playerInStayableAnimation = new ShootingInMovementAction<PlayerMovementSM>();
    float nextShotTime = 0f;
    PlayerMovementSM currentPlayerShooting;
    FirepointAction<PlayerShootingManager> shootingDirection = new FirepointAction<PlayerShootingManager>();
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
                playerInStayableAnimation.OnBeginShootingInMovement = Shot;
                value.ChangeAnimatorToShootingSM();
                PlayerShootingSM.OnShootingAction += FirstShot;
            }
            currentPlayerShooting = value;
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
        playerInStayableAnimation.PlayerInShootingSM = CurrentPlayerShooting;
        currentPlayerShooting = null;
    }
}