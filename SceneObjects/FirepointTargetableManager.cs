using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirepointTargetableManager: MonoBehaviour
{
    public List<FirepointTargetable> firepointTargetables = new List<FirepointTargetable>();
    FirepointTargetableSetTransform firepointTargetableSetTransform = new FirepointTargetableSetTransform();
    private void Start()
    {
        StartCoroutine("AddFirepointTargetableAction");
    }
    public void AddFirepointTargetable(FirepointTargetable currentFirepointTargetable)
    {
        firepointTargetables.Add(currentFirepointTargetable);
    }
    public void SetFirepointTransforms()
    {
        firepointTargetableSetTransform.CurrentFirepointTargetables = firepointTargetables;
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