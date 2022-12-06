using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class FirepointTargetable: MonoBehaviour
{
    public abstract FirepointAction TargetableFirepointAction { get; }
    public abstract void FirepointAction(Transform firepointTransform);
    public virtual void SetCurrentFirepointTransform(Transform firepointTransform)
    {
        TargetableFirepointAction.CurrentFirepointTransform = firepointTransform;
    }
}