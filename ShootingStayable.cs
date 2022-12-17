using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStayable : ShootingTemplate
{
    //public override PlayerShootingManager FinishShooting
    //{
    //    get
    //    {
    //        PlayerMovement.OnPlayerPressFireButton -= StayableMode;
    //        CurrentPlayerShooting.OnShooting = null;
    //        return base.FinishShooting;
    //    }
    //    set
    //    {
    //        if (value != null)
    //        {
    //            PlayerMovement.OnPlayerPressFireButton += StayableMode;
    //        }
    //        base.FinishShooting = value;
    //    }
    //}
    //void StayableMode(PlayerShootingManager currentPlayerShooting)
    //{
    //    currentPlayerShooting.TriggerOn();
    //}
}
