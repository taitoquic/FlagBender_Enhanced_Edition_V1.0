using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirepointTargetableManager: MonoBehaviour
{
    public List<FirepointTargetable> firepointTargetables = new List<FirepointTargetable>();
    private void Start()
    {
        StartCoroutine("AddFirepointTargetableAction");        
    }
    public void GetFirepointTransform(Transform firepointTransform)
    {
        foreach (FirepointTargetable firepointTargetable in firepointTargetables)
        {
            firepointTargetable.CurrentFirepointTransform = firepointTransform;
        }
    }
    public void AddFirepointTargetable(FirepointTargetable currentFirepointTargetable)
    {
        firepointTargetables.Add(currentFirepointTargetable);
    }

    public IEnumerator AddFirepointTargetableAction()
    {
        int indexChecked = 0;
        while (indexChecked != firepointTargetables.Count) 
        {
            if (firepointTargetables[indexChecked].CurrentFirepointTransform != null)
            {
                firepointTargetables[indexChecked].TargetableFirepointAction.OnFirepointActionValid = firepointTargetables[indexChecked].FirepointAction;
                indexChecked++;
            }
            else
            {
                yield return null;
            }
        }
    }
}