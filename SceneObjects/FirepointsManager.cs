using UnityEngine;

public class FirepointsManager : MonoBehaviour
{
    public FirepointTargetable[] firepointsTargeteables;
    public GameObject[] firepoints = new GameObject[3];
    int currentFirepoint;

    delegate void FirepointEnableAction(int targetFirepointIndex);
    FirepointEnableAction OnEnableFirepoint;

    bool FirepointEnabled
    {
        get
        {
            FPTargetableActions();
            OnEnableFirepoint = EnableFirepointAfterAction;
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
    int CurrentFirepoint
    {
        get
        {
            PlayerMovementSM.OnMovementSMAction -= ChangeToOtherMovementState;
            return currentFirepoint;
        }
        set
        {
            firepoints[value].SetActive(FirepointEnabled);
            PlayerMovementSM.OnMovementSMAction += ChangeToOtherMovementState;
            currentFirepoint = value;
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
        CurrentFirepoint = targetFirepointIndex;
    }
    void EnableFirepointAfterAction(int targetFirepointIndex)
    {
        if (currentFirepoint != targetFirepointIndex)
        {
            firepoints[currentFirepoint].SetActive(FirepointDisabled);
            OnEnableFirepoint?.Invoke(targetFirepointIndex);
        }
        else
        {
            PlayerMovementSM.OnMovementSMAction += ChangeToOtherMovementState;
        }
    }
    void ChangeToOtherMovementState()
    {
        firepoints[CurrentFirepoint].SetActive(FirepointDisabled);
    }
    void FPTargetableActions()
    {
        for (int i = 0; i < firepointsTargeteables.Length; i++)
        {
            firepointsTargeteables[i].EnableTargetableAction();
        }
    }
}