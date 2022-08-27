using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShooting : MonoBehaviour
{
    public Transform[] firepoints = new Transform[3];
    public GameObject bulletPrefab;
    public float cadencyShot = 0.4f;
    float nextShotTime = 0f;
    int stateIndex;

    public UnityEvent OnWeaponTriggered;

    delegate void OnPlayerShooting(int stateIndex);
    OnPlayerShooting OnTriggerInMovement;

    int StateIndex
    {
        set
        {
            stateIndex = value;
            if (value != 0)
            {
                OnTriggerInMovement += ShotInState;
                OnTriggerInMovement?.Invoke(value);
            }
        }
    }
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
                PlayerShootingSM.OnStateAction += GetShotState;
                OnWeaponTriggered.Invoke();
            }
            else
            {
                OnTriggerInMovement?.Invoke(stateIndex);
            }
        }
    }
    public void Shoot()
    {
        if (Time.time < nextShotTime) return;
        nextShotTime = Time.time + cadencyShot;

        CanPrepareShot = !IsShotPrepared;
    }

    void ShotInState(int stateIndex)
    {
        Instantiate(bulletPrefab, firepoints[stateIndex].position, firepoints[stateIndex].rotation);
    }
    void GetShotState(int stateIndex)
    {
        StateIndex = stateIndex;
        PlayerShootingSM.OnShotAction += ExitShotState;
        PlayerShootingSM.OnStateAction -= GetShotState;
    }
    void ExitShotState()
    {
        OnTriggerInMovement -= ShotInState;
        PlayerShootingSM.OnShotAction -= ExitShotState;
    }

    void StandShot()
    {
        Instantiate(bulletPrefab, firepoints[0].position, firepoints[0].rotation);
    }
}
