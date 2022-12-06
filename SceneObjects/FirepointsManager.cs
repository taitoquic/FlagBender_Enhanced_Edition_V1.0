using System.Collections;
using UnityEngine;
public class FirepointsManager : MonoBehaviour
{
    public GameObject[] firepoints = new GameObject[3];
    public FirepointTargetable[] firepointTargetables = new FirepointTargetable[2];
    FirepointTargetableManager firepointTargetableManager = new FirepointTargetableManager();

    delegate void FirepointEnableAction(int targetFirepointIndex);
    FirepointEnableAction OnEnableFirepoint;
    bool FirepointEnabled
    {
        get
        {
            OnEnableFirepoint = DisableTargetFirepoint;
            return true;
        }
    }
    bool FirepointDisabled
    {
        get
        {
            OnEnableFirepoint = EnableTargetFirepoint;
            Firepoint.OnFirepointAction += GetFirepointTransform;
            return false;
        }
    }
    FirepointTargetableManager FirepointTargetableManager
    {
        get
        {
            Firepoint.OnFirepointAction -= GetFirepointTransform;
            return firepointTargetableManager;
        }
    }
    private void Start()
    {
        OnEnableFirepoint = EnableTargetFirepoint;
        Firepoint.OnFirepointAction += GetFirepointTransform;
        StartCoroutine(firepointTargetableManager.AddFirepointTargetableAction(firepointTargetables));
    }
    public void EnableFirepointsManager(int targetFirepointIndex)
    {
        OnEnableFirepoint?.Invoke(targetFirepointIndex);
    }
    void EnableTargetFirepoint(int targetFirepointIndex)
    {
        firepoints[targetFirepointIndex].SetActive(FirepointEnabled);
    }
    void DisableTargetFirepoint(int targetFirepointIndex)
    {
        firepoints[targetFirepointIndex].SetActive(FirepointDisabled);
    }
    void GetFirepointTransform(Transform firepointTransform)
    {
        FirepointTargetableManager.CurrentFirepointTransform = firepointTransform;
        firepointTargetableManager.EnableTargetableActions(firepointTargetables);
    }
}