using System.Collections;
using UnityEngine;
public class FirepointsManager : MonoBehaviour
{
    public GameObject[] firepoints = new GameObject[3];
    FirepointTargetableManager newFirepointTransform;

    delegate void FirepointEnableAction(int targetFirepointIndex);
    FirepointEnableAction OnEnableFirepoint;

    FirepointTargetableManager FirepointTargetableManager
    {
        get
        {
            return GetComponent<FirepointTargetableManager>();
        }
    }
    FirepointTargetableManager NewFirepointTransform
    {
        get
        {
            Firepoint.OnFirepointAction -= newFirepointTransform.GetFirepointTransform;
            return null;
        }
        set
        {
            if (value != null)
            {
                Firepoint.OnFirepointAction += NewFirepointTransformActions;
                newFirepointTransform = value;
            }
        }
    }
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
            NewFirepointTransform = FirepointTargetableManager;
            return false;
        }
    }
    private void Start()
    {
        OnEnableFirepoint = EnableTargetFirepoint;
        newFirepointTransform = GetComponent<FirepointTargetableManager>();
        //NewFirepointTransform = FirepointTargetableManager;
        //NewFirepointTransform = GameManager.instance.firepointTargetableManager;
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
    void NewFirepointTransformActions(Transform firepointTransform)
    {
        newFirepointTransform.GetFirepointTransform(firepointTransform);
        newFirepointTransform = NewFirepointTransform;
    }
}