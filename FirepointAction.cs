using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirepointAction
{
    Transform currentFirepointTransform;
    public int CurrentFirepointIndex
    {
        get
        {
            return currentFirepointTransform.GetSiblingIndex();
        }
    }

    public delegate void TargetFirepointAction(Transform currentFirepoint);
    public TargetFirepointAction OnFirepointActionValid;
    public Transform CurrentFirepointTransform
    {
        get
        {
            return currentFirepointTransform;
        }
        set
        {
            if(value != null)
            {
                currentFirepointTransform = value;
            }
        }
    }
    public void ResolveFirepointAction()
    {
        OnFirepointActionValid?.Invoke(currentFirepointTransform);
    }
}