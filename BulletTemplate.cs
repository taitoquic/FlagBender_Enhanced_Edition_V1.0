using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Bullet", menuName ="Bullet")]
public class BulletTemplate : ScriptableObject
{
    public GameObject bulletPrefab;
    public float cadencyShot;
}