using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingModeStand : ShootingMode
{
    public override PlayerShootingManager CurrentShootingModeFirstShot
    {
        set
        {
            if (value != null)
            {
                value.CalculateTimeForNextShot();
            }
            base.CurrentShootingModeFirstShot = value;
        }
    }
}
