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

    public virtual Transform CurrentFirepointTransform
    {
        get
        {
            return TargetableFirepointAction.CurrentFirepointTransform;
        }
        set
        {
            if (value != null)
            {
                TargetableFirepointAction.CurrentFirepointTransform = value;
            }
        }
    }
    public abstract void FirepointAction(Transform firepointTransform);
}