using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SMShootingFeature : MonoBehaviour
{
    //PlayerShootingManager currentShootingManager;
    //bool shootingAfterFirstShot = false;
    //public PlayerShootingManager CurrentShootingManager
    //{
    //    get
    //    {
    //        return currentShootingManager;
    //    }
    //    set
    //    {
    //        currentShootingManager = value;
    //    }
    //}

}
//public delegate void MovementSMActions();
//public MovementSMActions OnCurrentSMAction;

//public delegate void CurrentShootingInstructions(PlayerShootingManager currentShootingManager);
//public static event CurrentShootingInstructions OnShootingInstructions;

//public PlayerShootingManager CurrentShootingManager
//{
//    get
//    {
//        return currentShootingManager;
//    }
//    set
//    {
//        if (value != null)
//        {
//            PlayerShootingSM.OnShootingAction += RealizeFirstShot;
//        }
//        else
//        {
//            PlayerShootingSM.OnShootingAction -= RealizeFirstShot;
//        }
//        currentShootingManager = value;
//        OnCurrentSMAction?.Invoke();
//    }
//}
//public bool ShootingAfterFirstShot
//{
//    get
//    {
//        if (shootingAfterFirstShot)
//        {
//            shootingAfterFirstShot = false;
//            return true;
//        }
//        return shootingAfterFirstShot;
//    }
//    set
//    {
//        if (!value)
//        {
//            OnCurrentSMAction = null;
//        }
//        CurrentShootingManager = null;
//        shootingAfterFirstShot = value;
//    }
//}
//public bool FirstShotDone
//{
//    get
//    {
//        return OnShootingInstructions == null;
//    }
//}
//public void MovementSMShooting(PlayerShootingManager currentShootingManager)
//{
//    CurrentShootingManager = currentShootingManager;
//}
//void RealizeFirstShot()
//{
//    OnShootingInstructions?.Invoke(currentShootingManager);
//}