using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirepointTargetableManager: MonoBehaviour
{
    public List<FirepointTargetable> firepointTargetables = new List<FirepointTargetable>();

    List<FirepointTargetable> FirepointTargetables
    {
        get
        {
            Firepoint.OnFirepointAction -= GetFirepointTransform;
            return firepointTargetables;
        }
        set
        {
            if (value != null)
            {
                Firepoint.OnFirepointAction += GetFirepointTransform;
            }
        }
    }
    private void Start()
    {
        StartCoroutine("AddFirepointTargetableAction");
    }
    public void AddFirepointTargetable(FirepointTargetable currentFirepointTargetable)
    {
        firepointTargetables.Add(currentFirepointTargetable);
    }
    public void SetAllFirepointTransforms()
    {
        FirepointTargetables = firepointTargetables;
    }
    void GetFirepointTransform(Transform firepointTransform)
    {
        foreach (FirepointTargetable firepointTargetable in FirepointTargetables)
        {
            firepointTargetable.SetFirepointTransform(firepointTransform);
        }
    }
    public IEnumerator AddFirepointTargetableAction()
    {
        int indexChecked = 0;
        FirepointAction currentAction;
        while (indexChecked != firepointTargetables.Count) 
        {
            currentAction = firepointTargetables[indexChecked].TargetableFirepointAction;
            if (currentAction.CurrentFirepointTransform != null) 
            {
                currentAction.OnFirepointActionValid = firepointTargetables[indexChecked].FirepointAction;
                indexChecked++;
            }
            else
            {
                yield return null;
            }
        }
    }
}