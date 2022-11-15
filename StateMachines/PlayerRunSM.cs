using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunSM : PlayerMovementSM
{
    public override Animator ShootingAnimator
    {
        get
        {
            //PlayerMovement.OnPlayerPressFireButton -= ShootingInMovement;
            return null;
        }
        set
        {
            //PlayerMovement.OnPlayerPressFireButton += ShootingInMovement;
        }
    }
    //void ShootingInMovement(PlayerShootingManager currentShootingManager)
    //{
    //    currentShootingManager.Shot();
    //}
}