using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingActionStayable : ShootingAction
{
    public override PlayerShootingManager PlayerFirstShot
    {
        set
        {
            if (value != null)
            {
                StayableShooting(value);
            }
            base.PlayerFirstShot = value;
        }
    }
    public override PlayerShootingManager PlayerAfterFirstShot
    {
        get
        {
            PlayerMovement.OnPlayerPressFireButton -= StayableShooting;
            return base.PlayerAfterFirstShot;
        }
        set
        {
            PlayerMovement.OnPlayerPressFireButton += StayableShooting;
            base.PlayerAfterFirstShot = value;
        }
    }
    void StayableShooting(PlayerShootingManager currentPlayerShooting)
    {
        currentPlayerShooting.Shot();
        currentPlayerShooting.CalculateTimeForNextShot();
    }
}