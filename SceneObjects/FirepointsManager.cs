using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FirepointsManager : MonoBehaviour
{
    public GameObject[] firepoints = new GameObject[3];
    public List<FirepointTargetable> firepointTargetables = new List<FirepointTargetable>();
    int targetFirepointIndex;
    bool targetFirepointEnabled = true;
    FirepointState currentFirepointState = new FirepointStateJumping();
    FirepointTargetableManager currentFirepointTargetableManager = new FirepointTargetableManager();

    delegate void FirepointAction(GameObject currentFirepoint);
    FirepointAction OnEnableFirepoint;
    FirepointStateJumping JumpingFirepointState
    {
        get
        {
            return (FirepointStateJumping)currentFirepointState;
        }
    }
    GameObject[] Firepoints
    {
        get
        {
            TargetFirepointEnabled = !targetFirepointEnabled;
            return firepoints;
        }
    }
    int TargetFirepointIndex
    {
        get
        {
            FirepointState.OnFirepointDisable -= DisableTargetFirepoint;
            return targetFirepointIndex;
        }
        set
        {
            TargetFirepoint = Firepoints[value];
            FirepointState.OnFirepointDisable += DisableTargetFirepoint;
            targetFirepointIndex = value;
        }
    }
    int JumpFirepointIndex
    {
        set
        {
            OnEnableFirepoint = EnableJumpingFirepoint;
            TargetFirepointIndex = value;
        }
    }
    bool TargetFirepointEnabled
    {
        get
        {
            FirepointActivableSM.OnEnableFirepoint -= SetStandardFirepoint;
            PlayerJumpSM.OnEnableAirFirepoint -= SetJumpingFirepoint;
            return targetFirepointEnabled;
        }
        set
        {
            if (!value)
            {
                FirepointActivableSM.OnEnableFirepoint += SetStandardFirepoint;
                PlayerJumpSM.OnEnableAirFirepoint += SetJumpingFirepoint;
                OnEnableFirepoint = EnableCurrentFirepoint;
                currentFirepointTargetableManager.CurrentFirepointTargetables = firepointTargetables;
            }
            targetFirepointEnabled = value;
        }
    }
    GameObject TargetFirepoint
    {
        get
        {
            return Firepoints[TargetFirepointIndex];
        }
        set
        {
            if (value != null)
            {
                value.SetActive(TargetFirepointEnabled);
                OnEnableFirepoint?.Invoke(value);
            }
        }
    }
    private void Start()
    {
        TargetFirepointEnabled = false;
    }
    void SetStandardFirepoint(int firepointIndex)
    {
        TargetFirepointIndex = firepointIndex;
    }
    void SetJumpingFirepoint(int firepointIndex)
    {
        JumpFirepointIndex = firepointIndex;
    }
    void EnableCurrentFirepoint(GameObject currentFirepoint)
    {
        currentFirepointState.CurrentFirepoint = currentFirepoint;
    }
    void EnableJumpingFirepoint(GameObject currentFirepoint)
    {
        JumpingFirepointState.JumpFirepoint = currentFirepoint;
    }
    void DisableTargetFirepoint()
    {
        TargetFirepoint.SetActive(targetFirepointEnabled);
    }
}