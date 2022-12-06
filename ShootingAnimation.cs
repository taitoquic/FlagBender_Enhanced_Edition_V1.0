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
            ShootingAction.OnShootingActions -= PlayShootingAnimation;
            PlayerMovementSM.OnMovementSMAction -= EndWithoutPlayAnimation;
            PlayerMovement.OnPlayerPressFireButton -= PlayerShooting;
            return currentAnimator;
        }
        set
        {
            if(value != null)
            {
                ShootingAction.OnShootingActions += PlayShootingAnimation;
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
            PlayerMovementSM.OnMovementSMAction -= EndPlayAnimation;
            return null;
        }
        set
        {
            if(value != null)
            {
                value.SetTrigger("Shooting");
                PlayerMovementSM.OnMovementSMAction += EndPlayAnimation;
            }
        }
    }
    void PlayerShooting(PlayerShootingManager currenPlayerShooting)
    {
        playerShootingAction.PlayerShootingManager = currenPlayerShooting;
    }
    void PlayShootingAnimation()
    {
        ShootingAnimator = CurrentAnimator;
    }
    void EndWithoutPlayAnimation()
    {
        CurrentAnimator = null;
    }
    void EndPlayAnimation()
    {
        currentAnimator = ShootingAnimator;
    }
}