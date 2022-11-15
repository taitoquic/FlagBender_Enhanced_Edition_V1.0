using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirepointAction<T>where T: FirepointTargetable
{
    T currentFPTargetable;
    Transform firepointTransform;

    delegate void TargetableFPAction(Transform currentTransform);
    TargetableFPAction OnFPTargetableAction;

    public T CurrentFPTargetable
    {
        get
        {
            Firepoint.OnFirepointAction -= GetCurrentFirepoint;
            return currentFPTargetable;
        }
        set
        {
            if(value != null)
            {
                Firepoint.OnFirepointAction += GetCurrentFirepoint;
            }
            currentFPTargetable = value;
        }
    }
    T FPTargetableAddFunction
    {
        set
        {
            OnFPTargetableAction = value.PlayerFPAction;
            CurrentFPTargetable = null;
        }
    }
    Transform FirepointTransform
    {
        set
        {
            if(value != null)
            {
                FPTargetableAddFunction = CurrentFPTargetable;
            }
            else
            {
                OnFPTargetableAction = null;
            }
            firepointTransform = value;
        }
    }
    void GetCurrentFirepoint(Transform targetTransform)
    {
        FirepointTransform = targetTransform;
    }
    public void ResolveFirepointAction()
    {
        OnFPTargetableAction?.Invoke(firepointTransform);
    }
}
