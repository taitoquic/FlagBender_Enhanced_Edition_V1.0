using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAnimation 
{
    Animator currentAnimator;
    ShootingAction playerShootingAction = new ShootingAction();
    public Animator CurrentAnimator
    {
        get
        {
            PlayerMovementSM.OnMovementSMAction -= EndWithoutPlayAnimation;
            PlayerMovement.OnPlayerPressFireButton -= PlayerShooting;
            return currentAnimator;
        }
        set
        {
            if(value != null)
            {
                PlayerMovementSM.OnMovementSMAction += EndWithoutPlayAnimation;
                PlayerMovement.OnPlayerPressFireButton += PlayerShooting;
            }
            else
            {
                currentAnimator = CurrentAnimator;
            }
            currentAnimator = value;
        }
    }
    Animator ShootingAnimator
    {
        get
        {
            currentAnimator.SetTrigger("Shooting");
            ShootingAction.OnShootingActions -= PlayShootingAnimation;
            return null;
        }
        set
        {
            ShootingAction.OnShootingActions += PlayShootingAnimation;
        }
    }
    ShootingAction TriggerShooting
    {
        get
        {
            ShootingAnimator = CurrentAnimator;
            return playerShootingAction;
        }
    }
    void PlayerShooting(PlayerShootingManager currenPlayerShooting)
    {
        TriggerShooting.PlayerShootingManager = currenPlayerShooting;
    }
    void PlayShootingAnimation()
    {
        currentAnimator = ShootingAnimator;
    }
    void EndWithoutPlayAnimation()
    {
        CurrentAnimator = null;
    }
}