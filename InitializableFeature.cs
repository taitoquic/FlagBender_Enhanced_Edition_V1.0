using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializableFeature : MonoBehaviour
{
    List<IInitializable> currentInitializables;
    bool firepointTargetablesReady = false;

    public delegate void EndOfInitializables();
    public static event EndOfInitializables OnEndInitializables;
    public List<IInitializable> CurrentInitializables
    {
        get
        {
            OnEndInitializables?.Invoke();
            return null;
        }
        set
        {
            if (value != null)
            {
                FirepointTargetablesReady = firepointTargetablesReady;
                currentInitializables = value;
            }
        }
    }
    bool FirepointTargetablesReady
    {
        get
        {
            Firepoint.OnFirepointAction -= FirstFirepointTargetEnabled;
            return true;
        }
        set
        {
            if (value)
            {
                firepointTargetablesReady = FirepointTargetablesReady;
            }
            else
            {
                Firepoint.OnFirepointAction += FirstFirepointTargetEnabled;
                StartCoroutine("WaitForFirepointTargetableCondition");
            }
        }
    }
    void AddListenerToInitializables()
    {
        foreach (IInitializable initializable in currentInitializables)
        {
            initializable.OnInitialize.AddListener(initializable.ActionToInitialize);
        }
        currentInitializables = CurrentInitializables;
    }
    IEnumerator WaitForFirepointTargetableCondition()
    {
        while (!firepointTargetablesReady)
        {
            yield return null;
        }
        AddListenerToInitializables();
    }
    void FirstFirepointTargetEnabled(Transform firepointTransform)
    {
        FirepointTargetablesReady = firepointTransform != null;
    }
}