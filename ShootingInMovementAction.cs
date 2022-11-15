using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingInMovementAction <T> where T:PlayerMovementSM
{
    T currentMovementSM;
    public T CurrentMovementSM
    {
        get
        {
            PlayerMovement.OnPlayerPressFireButton -= ShootingInMovement;
            return currentMovementSM;
        }
        set
        {
            if(value != null)
            {
                PlayerMovement.OnPlayerPressFireButton += ShootingInMovement;
            }
            else
            {

            }
            currentMovementSM = value;
        }
    }
    void ShootingInMovement(PlayerShootingManager currentShootingManager)
    {
        currentShootingManager.Shot();
    }
}
