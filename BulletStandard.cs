using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Bullet", menuName = "Bullet/Standard Bullet")]
public class BulletStandard : BulletTemplate, IBolterChargable
{
    public GameObject chargedBulletPrefab;
    public GameObject ChargedBulletPrefab
    {
        get
        {
            return chargedBulletPrefab;
        }
    }

    public override void ActionsToEquip()
    {
        GameManager.instance.chargableFeature.CurrentChargable = this;
    }

    public override void ActionsToUnequip()
    {
        GameManager.instance.chargableFeature.CurrentChargable = null;
    }
}