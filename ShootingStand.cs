using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShootingStand: ShootingTemplate
{
    public override PlayerShootingManager ShootingPlayer
    {
        get
        {
            return base.ShootingPlayer;
        }
        set
        {
            if (value != null)
            {
                value.OnShooting = null;
            }
            base.ShootingPlayer = value;
        }
    }
}