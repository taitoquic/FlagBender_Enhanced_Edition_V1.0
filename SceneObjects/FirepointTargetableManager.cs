using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirepointTargetableManager
{
    List<FirepointTargetable> currentFirepointTargetables;
    public List<FirepointTargetable> CurrentFirepointTargetables
    {
        get
        {
            Firepoint.OnFirepointAction -= SetFirepointTransform;
            return null;
        }
        set
        {
            if (value != null)
            {
                Firepoint.OnFirepointAction += SetFirepointTransform;
            }
            currentFirepointTargetables = value;
        }
    }
    void SetFirepointTransform(Transform firepointTransform)
    {
        foreach (FirepointTargetable firepointTargetable in currentFirepointTargetables)
        {
            firepointTargetable.FirepointTransform = firepointTransform;
        }
        currentFirepointTargetables = CurrentFirepointTargetables;
    }
}