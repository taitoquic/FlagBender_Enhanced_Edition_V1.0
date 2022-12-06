using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirepointTargetableManager 
{
    Transform currentFirepointTransform;
    public Transform CurrentFirepointTransform
    {
        set
        {
            if(value != null)
            {
                currentFirepointTransform = value;
            }
        }
    }
    public void EnableTargetableActions(FirepointTargetable[] firepointTargetables)
    {
        for (int i = 0; i < firepointTargetables.Length; i++)
        {
            firepointTargetables[i].SetCurrentFirepointTransform(currentFirepointTransform);
        }
    }
    public IEnumerator AddFirepointTargetableAction(FirepointTargetable[] firepointTargetables)
    {
        while (!FirepointsTargetablesTransformsValid(firepointTargetables))
        {
            yield return null;
        }
        for (int i = 0; i < firepointTargetables.Length; i++)
        {
            firepointTargetables[i].TargetableFirepointAction.OnFirepointActionValid = firepointTargetables[i].FirepointAction;
        }
    }
    bool FirepointsTargetablesTransformsValid(FirepointTargetable[] firepointTargetables)
    {
        for (int i = 0; i < firepointTargetables.Length; i++)
        {
            if (firepointTargetables[i].TargetableFirepointAction.CurrentFirepointTransform == null)
            {
                return false;
            }
        }
        return true;
    }
}