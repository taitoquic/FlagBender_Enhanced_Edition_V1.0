using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class FirepointTargetable: MonoBehaviour, IInitializable
{
    Transform firepointTransform;
    public UnityEvent OnFirepointAction;
    public virtual Transform FirepointTransform
    {
        get
        {
            return firepointTransform;
        }
        set
        {
            if (value != null)
            {
                firepointTransform = value;
            }
        }
    }
    public UnityEvent OnInitialize
    {
        get
        {
            return OnFirepointAction;
        }
    }
    private void Awake()
    {
        GameManager.instance.firepointsManager.firepointTargetables.Add(this);
        GameManager.instance.initializables.Add(this);
    }
    public abstract void ActionToInitialize();
}