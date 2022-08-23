using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform[] firepoints = new Transform[3];
    public GameObject bulletPrefab;
    public float cadencyShot = 0f;
    public void Shoot()
    {

    }

    void StandShot()
    {
        Instantiate(bulletPrefab, firepoints[0].position, firepoints[0].rotation);
    }
}
