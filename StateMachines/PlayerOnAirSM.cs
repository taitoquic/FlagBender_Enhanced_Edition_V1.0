using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerOnAirSM : PlayerMovementSM
{
    ShootingAction shootingModeOnAir = new ShootingActionStayable();

    //public static event ActionInMovementState OnAirFirepointEnable;
    public override int StateIndex
    {
        get
        {
            return 2;
        }
    }
    public override ShootingAction ShootingMode
    {
        get
        {
            return shootingModeOnAir;
        }
    }
    //string PlayerOnAir
    //{
    //    get
    //    {
    //        OnAirFirepointEnable?.Invoke(StateIndex);
    //        return "IsOnAir";
    //    }
    //}
    //Animator OnAirAnimator
    //{
    //    set
    //    {
    //        if (value != null)
    //        {
    //            value.SetBool(PlayerOnAir, true);
    //        }
    //    }
    //}

}
//public override ShootingAction ShootingMode
//{
//    get
//    {
//        PlayerJumpSM.OnPlayerJumpSM -= PrepareAirShooting;
//        PlayerFallSM.OnFallActionSM -= PrepareAirShooting;
//        return shootingModeOnAir;
//    }
//}
//bool PlayerIsOnAir
//{
//    get
//    {
//        OnAirEnableFirepoint?.Invoke(StateIndex);
//        return true;
//    }
//}
//public override Animator CurrentAnimator 
//{
//    set
//    {
//        if (value != null)
//        {
//            value.SetBool("IsOnAir", PlayerIsOnAir);
//            PlayerJumpSM.OnPlayerJumpSM += PrepareAirShooting;
//            PlayerFallSM.OnFallActionSM += PrepareAirShooting;
//        }
//    }
//}
//void PrepareAirShooting(Animator currentAnimator)
//{
//    ShootingMode.CurrentAnimator = currentAnimator;
//}
//public static event ActionInMovementState OnAirEnableFirepoint;
//public delegate void AirMovementAnimatorAction(Animator currentAnimator);