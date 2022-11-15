using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMShootingManager:MonoBehaviour
{
    //public SMShootingFeature sMCurrentShootingFeature;
    PlayerMovementSM currentSM;
    //public PlayerMovementSM CurrentSM
    //{
    //    get
    //    {
    //        PlayerMovement.OnPlayerPressFireButton -= EnableStayableShooting;
    //        //PlayerShootingManager.OnShooting -= CurrentSMBeginShooting;
    //        return currentSM;
    //    }
    //    set
    //    {
    //        if (value != null)
    //        {
    //            PlayerMovement.OnPlayerPressFireButton += EnableStayableShooting;
    //            //PlayerShootingManager.OnShooting += CurrentSMBeginShooting;
    //        }
    //        //else if(!CurrentSMHasShoot)
    //        //{
    //        //    PlayerMovement.OnPlayerPressFireButton -= EnableStayableShooting;
    //        //}
    //        currentSM = value;
    //    }
    //}
    //bool CurrentSMHasShoot
    //{
    //    get
    //    {
    //        return currentSM.OnMovementSMAction == null;
    //    }
    //}
    //PlayerMovementSM CurrentSMShooting
    //{
    //    get
    //    {
    //        //SMShootingFeature.OnShootingInstructions -= currentSM.ShootingInstructions;
    //        //PlayerShootingSM.OnShootingAction -= FirstShotActions;
    //        //PlayerShootingSM.OnShootingAction += ExitMovementState;
    //        //return currentSM;
    //    }
    //    set
    //    {
    //        value.BeginShootingAnimation();
    //        //PlayerShootingSM.OnShootingAction += FirstShotActions;
    //        //value.BeginShootingAnimation();
    //    }
    //}

    //void CurrentSMBeginShooting()
    //{
    //    currentSM.CurrentSMShooting = CurrentSM;
    //}
    //void EnableStayableShooting(PlayerShootingManager currentShootingManager)
    //{
    //    currentShootingManager.StayableShooting = !currentSM.ShootingInAnimation;
    //}
    //void ExitMovementState()
    //{
    //    //if (!sMCurrentShootingFeature.FirstShotDone)
    //    //{
    //    //    CurrentSM = null;
    //    //}
    //    //else if (!sMCurrentShootingFeature.ShootingAfterFirstShot)
    //    //{
    //    //    PlayerShootingSM.OnShootingAction -= ExitMovementState;
    //    //}
    //    //else
    //    //{
    //    //    PlayerMovement.OnPlayerPressFireButton -= currentSM.ShootingInstructions;
    //    //    PlayerShootingSM.OnShootingAction -= ExitMovementState;
    //    //}
    //    EndMovementSM = CurrentSM;
    //}

}


//PlayerMovementSM CurrentSMShooting
//{
//    get
//    {
//        SMShootingFeature.OnShootingInstructions -= currentSM.ShootingInstructions;
//        PlayerShootingSM.OnShootingAction -= FirstShotActions;
//        PlayerShootingSM.OnShootingAction += ExitMovementState;
//        return currentSM;
//    }
//    set
//    {
//        PlayerShootingSM.OnShootingAction += FirstShotActions;
//        value.BeginShootingAnimation();
//    }
//}
//SMShootingFeature SMCurrentShootingFeature
//{
//    get
//    {
//        //PlayerMovementSM.OnMovementSMAction += ExitMovementState;
//        //PlayerMovement.OnPlayerPressFireButton += sMCurrentShootingFeature.MovementSMShooting;
//        CurrentSMShooting = CurrentSM;
//        return sMCurrentShootingFeature;
//    }
//}
//void PlayerBeginShooting()
//{
//    CurrentSMShooting = CurrentSM;
//    sMCurrentShootingFeature.OnCurrentSMAction = ContinueShootingInMovement;
//}
//void FirstShotActions()
//{
//    sMCurrentShootingFeature.ShootingAfterFirstShot = CurrentSMShooting.StayableShotAllow;

//}
//void ContinueShootingInMovement()
//{
//    PlayerMovement.OnPlayerPressFireButton += currentSM.ShootingInstructions;
//    sMCurrentShootingFeature.OnCurrentSMAction = null;
//}
