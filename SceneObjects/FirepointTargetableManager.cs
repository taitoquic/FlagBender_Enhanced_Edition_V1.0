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
    public void AddFirepointTargetable(FirepointTargetable currentFirepointTargetable)
    {
        firepointTargetables.Add(currentFirepointTargetable);
    }
    public void GetFirepointTransform(Transform firepointTransform)
    {
        foreach (FirepointTargetable firepointTargetable in firepointTargetables)
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