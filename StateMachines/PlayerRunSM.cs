using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunSM : PlayerMovementSM
{
    ShootingAction shootingModeRun = new ShootingActionStayable();
    public override int StateIndex
    {
        get
        {
            return 1;
        }
    }
    public override ShootingAction ShootingMode
    {
        get
        {
            return shootingModeRun;
        }
    }
}