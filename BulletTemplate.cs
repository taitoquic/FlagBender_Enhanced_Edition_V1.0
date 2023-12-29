using UnityEngine;

public abstract class BulletTemplate : ScriptableObject
{
    public GameObject bulletPrefab;
    public float cadencyShot;

    public abstract void ActionsToEquip();
    public abstract void ActionsToUnequip();
}