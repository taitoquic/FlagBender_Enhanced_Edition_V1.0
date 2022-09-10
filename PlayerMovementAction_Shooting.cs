using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerMovementAction_Shooting 
{
    public GameObject bulletPrefab;
    public float cadencyShot = 0.4f;
    float nextShotTime = 0f;

    public bool HasPassedNecessaryTimeForShot
    {
        get
        {
            return Time.time > nextShotTime;
        }
    }

    public void CalculateTimeForNextShot()
    {
        nextShotTime = Time.time + cadencyShot;
    }
}
