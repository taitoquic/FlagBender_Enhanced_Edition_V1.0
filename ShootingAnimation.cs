using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAnimation 
{
    Animator currentAnimator;

    public delegate void PlayerShootingPrepared();
    public static event PlayerShootingPrepared OnShootingReady;
    public Animator CurrentAnimator
    {
        get
        {
            PlayerMovementSM.OnMovementSMAction -= EndWithoutPlayAnimation;
            ShootingAction.OnShootingActions -= PlayShootingAnimation;
            return currentAnimator;
        }
        set
        {
            if(value != null)
            {
                PlayerMovementSM.OnMovementSMAction += EndWithoutPlayAnimation;
                ShootingAction.OnShootingActions += PlayShootingAnimation;
                OnShootingReady?.Invoke();
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
            PlayerShootingSM.OnShootingAction -= EndShootingAnimation;
            return null;
        }
        set
        {
            if (value != null)
            {
                value.SetTrigger("Shooting");
                PlayerShootingSM.OnShootingAction += EndShootingAnimation;
            }
        }
    }
    void EndWithoutPlayAnimation()
    {
        CurrentAnimator = null;
    }
    void PlayShootingAnimation()
    {
        ShootingAnimator = CurrentAnimator;
    }
    void EndShootingAnimation()
    {
        currentAnimator = ShootingAnimator;
    }
}