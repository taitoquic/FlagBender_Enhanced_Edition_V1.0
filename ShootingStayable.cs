using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStayable : ShootingTemplate
{
    public override PlayerShootingManager ShootingPlayer
    {
        get
        {
            PlayerMovement.OnPlayerPressFireButton -= StayableMode;
            CurrentPlayerShooting.OnShooting = null;
            return base.ShootingPlayer;
        }
        set
        {
            if (value != null)
            {
                PlayerMovement.OnPlayerPressFireButton += StayableMode;
            }
            base.ShootingPlayer = value;
        }
    }
    void StayableMode(PlayerShootingManager currentPlayerShooting)
    {
        currentPlayerShooting.TriggerOn();
    }
}
