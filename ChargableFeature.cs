using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChargableFeature : MonoBehaviour
{
    IBolterChargable currentChargable;
    Animator currentAnimator;
    public PlayerShootingManager playerShootingManager;
    public UnityEvent<bool> OnBolterChargable;
    public IBolterChargable CurrentChargable
    {
        set
        {
            OnBolterChargable?.Invoke(value != null);
            currentChargable = value;
        }
    }
    public Animator CurrentAnimator
    {
        get
        {
            PlayerMovement.OnButtonUpFireButton -= FireButtonUpWithChargableSuccessful;
            FirepointActivableSM.OnEnterMovementSM -= ChargableCancelled;
            return currentAnimator;
        }
        set
        {
            if (value != null)
            {
                PlayerMovement.OnButtonUpFireButton += FireButtonUpWithChargableSuccessful;
                FirepointActivableSM.OnEnterMovementSM += ChargableCancelled;
            }
            else
            {
                currentAnimator = CurrentAnimator;
            }
            currentAnimator = value;
        }
    }
    Animator FireButtonUpCharged
    {
        get
        {
            PlayerShootingChargableSM.OnPlayerShootingChargable -= PlayerBeginShootingChargable;
            return currentAnimator;
        }
        set
        {
            if (value != null)
            {
                PlayerShootingChargableSM.OnPlayerShootingChargable += PlayerBeginShootingChargable;
                value.SetBool("ShootingChargable", true);
            }
        }
    }
    Animator BeginShootingChargable
    {
        get
        {
            PlayerShootingChargableSM.OnPlayerShootingChargable -= PlayerEndShootingChargable;
            return currentAnimator;
        }
        set
        {
            if (value != null)
            {
                PlayerShootingChargableSM.OnPlayerShootingChargable += PlayerEndShootingChargable;
                playerShootingManager.OnStopPlayerAtBeginShot.Invoke();
                playerShootingManager.CalculateTimeForNextShot();
            }
        }
    }
    Animator EndShootingChargable
    {
        get
        {
            FirepointActivableSM.OnEnterMovementSM -= EndChargableFeature;
            return null;
        }
        set
        {
            if (value != null)
            {
                value.SetBool("ShootingChargable", false);
                FirepointActivableSM.OnEnterMovementSM += EndChargableFeature;
                playerShootingManager.OnResumeMovementAtEndShot.Invoke();
            }
        }
    }
    void FireButtonUpWithChargableSuccessful()
    {
        FireButtonUpCharged = CurrentAnimator;
    }
    void ChargableCancelled()
    {
        CurrentAnimator = null;
    }
    void PlayerBeginShootingChargable()
    {
        BeginShootingChargable = FireButtonUpCharged;
    }
    void PlayerEndShootingChargable()
    {
        EndShootingChargable = BeginShootingChargable;
    }
    void EndChargableFeature()
    {
        currentAnimator = EndShootingChargable;
    }
    public void PlayerShootingChargable()
    {
        playerShootingManager.ShootingCustomGameObject(currentChargable.ChargedBulletPrefab);
    }
}