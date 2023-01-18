using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirepointTargetableAction 
{
    FirepointTargetableManager currentFirepointTargetableManager;

    public FirepointTargetableManager CurrentFirepointTargetableManager
    {
        get
        {
            Firepoint.OnFirepointAction -= GetCurrentFirepointTransform;
            return null;
        }
        set
        {
            if (value != null)
            {
                Firepoint.OnFirepointAction += GetCurrentFirepointTransform;
            }
            currentFirepointTargetableManager = value;
        }
    }
    void GetCurrentFirepointTransform(Transform firepointTransform)
    {
        currentFirepointTargetableManager.GetFirepointTransform(firepointTransform);
        currentFirepointTargetableManager = CurrentFirepointTargetableManager;
    }
}
