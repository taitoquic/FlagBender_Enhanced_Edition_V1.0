using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunSM : PlayerMovementSM
{
    public override bool StayableShotAllow
    {
        get
        {
            return true;
        }
    }
    public override void ShootingInstructions(PlayerShootingManager currentShootingManager)
    {
        currentShootingManager.Shot();
        base.ShootingInstructions(currentShootingManager);
    }
}