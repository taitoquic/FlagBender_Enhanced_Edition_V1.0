using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirepointTargetableSetTransform 
{
    List<FirepointTargetable> currentFirepointTargetables;
    public List<FirepointTargetable> CurrentFirepointTargetables
    {
        get
        {
            Firepoint.OnFirepointAction -= GetFirepointTransform;
            return null;
        }
        set
        {
            if (value != null)
            {
                Firepoint.OnFirepointAction += GetFirepointTransform;
            }
            currentFirepointTargetables = value;
        }
    }
    void GetFirepointTransform(Transform firepointTransform)
    {
        foreach (FirepointTargetable firepointTargetable in currentFirepointTargetables)
        {
            firepointTargetable.SetFirepointTransform(firepointTransform);
        }
        currentFirepointTargetables = CurrentFirepointTargetables;
    }
}
