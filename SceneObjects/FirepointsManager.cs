using UnityEngine;

public class FirepointsManager : MonoBehaviour
{
    public FirepointTargetable[] firepointsTargeteables;
    public GameObject[] firepoints = new GameObject[3];

    delegate void FirepointEnableAction(int targetFirepointIndex);
    FirepointEnableAction OnEnableFirepoint;

    bool FirepointEnabled
    {
        get
        {
            FPTargetableActions();
            OnEnableFirepoint = DisableTargetFirepoint;
            return true;
        }
    }
    bool FirepointDisabled
    {
        get
        {
            OnEnableFirepoint = EnableTargetFirepoint;
            return false;
        }
    }
    private void Start()
    {
        OnEnableFirepoint = EnableTargetFirepoint;
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
    void FPTargetableActions()
    {
        for (int i = 0; i < firepointsTargeteables.Length; i++)
        {
            firepointsTargeteables[i].EnableTargetableAction();
        }
    }
}