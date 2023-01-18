using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingActionStand : ShootingAction
{
    public override PlayerShootingManager PlayerFirstShot
    {
        set
        {
            if (value != null)
            {
                value.CalculateTimeForNextShot();
            }
            base.PlayerFirstShot = value;
        }
    }
}