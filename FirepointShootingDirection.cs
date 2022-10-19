using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirepointShootingDirection : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerShootingManager.OnPlayerShooting += GenerateBulletToDirection;
    }
    private void OnDisable()
    {
        PlayerShootingManager.OnPlayerShooting -= GenerateBulletToDirection;
    }
    void GenerateBulletToDirection(BulletTemplate bullet)
    {
        Instantiate(bullet.bulletPrefab, transform.position, transform.rotation);
    }
}
