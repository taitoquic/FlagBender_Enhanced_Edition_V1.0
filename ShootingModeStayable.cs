using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingModeStayable : ShootingMode
{
    public override PlayerShootingManager CurrentShootingModeFirstShot
    {
        get
        {
            PlayerMovement.OnPlayerPressFireButton -= StayableShooting;
            return base.CurrentShootingModeFirstShot;
        }
        set
        {
            if (value != null)
            {
                StayableShooting(value);
                PlayerMovement.OnPlayerPressFireButton += StayableShooting;
            }
            base.CurrentShootingModeFirstShot = value;
        }
    }
    void StayableShooting(PlayerShootingManager currentPlayerShooting)
    {
        currentPlayerShooting.Shot();
        currentPlayerShooting.CalculateTimeForNextShot();
    }
}