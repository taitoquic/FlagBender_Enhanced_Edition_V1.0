using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootingTemplate 
{
    //PlayerShootingManager currentPlayerShooting;

    //public delegate void EndShootingSM();
    //public static event EndShootingSM OnEndShooting;

    //public PlayerShootingManager CurrentPlayerShooting
    //{
    //    get
    //    {
    //        PlayerMovementSM.OnMovementSMAction -= ExitWithoutShooting;
    //        ShootingAction.OnShootingActions -= SetShootingInstructions;
    //        return currentPlayerShooting;
    //    }
    //    set
    //    {
    //        if (value != null)
    //        {
    //            PlayerMovementSM.OnMovementSMAction += ExitWithoutShooting;
    //            ShootingAction.OnShootingActions += SetShootingInstructions;
    //        }
    //        else
    //        {
    //            currentPlayerShooting = CurrentPlayerShooting;
    //        }
    //        //currentPlayerShooting = value;
    //    }
    //}
    //public virtual PlayerShootingManager PlayerShooting
    //{
    //    get
    //    {
    //        currentPlayerShooting.TriggerOn();
    //        PlayerShootingSM.OnShootingAction -= EndFirstShot;
    //        return null;
    //    }
    //    set
    //    {
    //        if (value != null)
    //        {
    //            //value.DefaultShot();
    //            PlayerShootingSM.OnShootingAction += EndFirstShot;
    //        }
    //        currentPlayerShooting = value;
    //    }
    //}
    //public virtual PlayerShootingManager FinishShooting
    //{
    //    get
    //    {
    //        OnEndShooting?.Invoke();
    //        PlayerShootingSM.OnShootingAction -= ExitShootingSM;
    //        return null;
    //    }
    //    set
    //    {
    //        if (value != null)
    //        {
    //            PlayerShootingSM.OnShootingAction += ExitShootingSM;
    //        }
    //        currentPlayerShooting = value;
    //    }
    //}
    //void SetShootingInstructions()
    //{
    //    PlayerShooting = CurrentPlayerShooting;
    //}
    //void EndFirstShot()
    //{
    //    currentPlayerShooting = PlayerShooting;
    //}
    //void ExitWithoutShooting()
    //{
    //    CurrentPlayerShooting = null;
    //}
    //void ExitShootingSM()
    //{
    //    currentPlayerShooting = FinishShooting;
    //}
}
