using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShooting : MonoBehaviour
{
    public Transform[] firepoints = new Transform[3];
    public GameObject bulletPrefab;
    public float cadencyShot = 1f;
    float nextShotTime = 0f;

    public UnityEvent OnWeaponTriggered;

    delegate void OnPlayerShooting();
    OnPlayerShooting OnTriggerInMovement;

    bool IsShotPrepared
    {
        get
        {
            return OnTriggerInMovement != null;
        }
    }
    bool CanPrepareShot
    {
        set
        {
            if (value)
            {
                PrepareShot = true;
            }
            else
            {
                OnTriggerInMovement?.Invoke();
            }
        }
    }

    bool PrepareShot
    {
        set
        {
            if (value)
            {
                StandShotSM.OnStandShotAction += OnEnterStandShotState;
                RunAndShotSM.OnRunAndShotAction += OnEnterRunAndShotState;
                OnAirShotSM.OnAirShotAction += OnEnterOnAirShotState;
                OnWeaponTriggered.Invoke();
            }
            else
            {
                StandShotSM.OnStandShotAction -= OnEnterStandShotState;
                RunAndShotSM.OnRunAndShotAction -= OnEnterRunAndShotState;
                OnAirShotSM.OnAirShotAction -= OnEnterOnAirShotState;
            }
        }
    }
    public void Shoot()
    {
        if (Time.time < nextShotTime) return;
        nextShotTime = Time.time + cadencyShot;

        CanPrepareShot = !IsShotPrepared;
    }


    void OnEnterStandShotState()
    {
        PrepareShot = false;
        StandShotSM.OnStandShotAction += OnExitStandShotState;
    }
    void OnExitStandShotState()
    {
        StandShotSM.OnStandShotAction -= OnExitStandShotState;
    }
    void OnEnterRunAndShotState()
    {
        PrepareShot = false;
        OnTriggerInMovement += RunAndShot;
        OnTriggerInMovement.Invoke();
        RunAndShotSM.OnRunAndShotAction += OnExitSRunAndShotState;
    }
    void OnExitSRunAndShotState()
    {
        OnTriggerInMovement -= RunAndShot;
        RunAndShotSM.OnRunAndShotAction -= OnExitSRunAndShotState;
    }
    void OnEnterOnAirShotState()
    {
        PrepareShot = false;
        OnTriggerInMovement += OnAirShot;
        OnTriggerInMovement.Invoke();
        OnAirShotSM.OnAirShotAction += OnExitOnAirShotState;
    }
    void OnExitOnAirShotState()
    {
        OnTriggerInMovement -= OnAirShot;
        OnAirShotSM.OnAirShotAction -= OnExitOnAirShotState;
    }

    void StandShot()
    {
        Instantiate(bulletPrefab, firepoints[0].position, firepoints[0].rotation);
    }
    void RunAndShot()
    {
        Instantiate(bulletPrefab, firepoints[1].position, firepoints[1].rotation);
    }
    void OnAirShot()
    {
        Instantiate(bulletPrefab, firepoints[2].position, firepoints[2].rotation);
    }
}
