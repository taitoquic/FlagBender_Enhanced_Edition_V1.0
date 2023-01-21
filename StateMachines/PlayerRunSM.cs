using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunSM : PlayerMovementSM
{
    public override int StateIndex
    {
        get
        {
            return 1;
        }
    }
    ShootingActionStayable ShootingModeStayable
    {
        get
        {
            return (ShootingActionStayable)ShootingModeStandard;
        }
    }
    public override void PlayerBeginToShooting(PlayerShootingManager playerShootingManager)
    {
        ShootingModeStayable.CurrentShootingManager = playerShootingManager;
    }
}