using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterBullet : MonoBehaviour
{
    public Rigidbody2D bulletRb;
    public float bulletSpeed = 20f;

    private void Start()
    {
        bulletRb.velocity = transform.right * bulletSpeed;
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}