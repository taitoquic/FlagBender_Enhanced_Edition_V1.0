using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class FirepointTargetable: MonoBehaviour
{
    private void Awake()
    {
        GameManager.instance.firepointTargetableManager.AddFirepointTargetable(this);
    }
    public abstract FirepointAction TargetableFirepointAction { get; }
    public virtual void SetFirepointTransform(Transform firepointTransform)
    {
        TargetableFirepointAction.CurrentFirepointTransform = firepointTransform;
    }
    public abstract void FirepointAction(Transform firepointTransform);
}