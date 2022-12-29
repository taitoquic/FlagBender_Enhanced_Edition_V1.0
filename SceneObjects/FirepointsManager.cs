using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FirepointsManager : MonoBehaviour
{
    public GameObject[] firepoints = new GameObject[3];
    ShootingMode[] shootingModes = new ShootingMode[2] { new ShootingModeStand(), new ShootingModeStayable() };
    int shootingModeIndex;
    ShootingAction shootingAction = new ShootingAction();
    FirepointShooting targetFirepointShooting = new FirepointShooting();
    FirepointTargetableManager FirepointTargetableManager
    {
        get
        {
            return GetComponent<FirepointTargetableManager>();
        }
    }
    bool EnableFirepointTargetables
    {
        get
        {
            FirepointTargetableManager.SetFirepointTransforms();
            return true;
        }
    }
    int ShootingModeIndex
    {
        get
        {
            ShootingAnimation.OnShootingReady -= SetShootingMode;
            return shootingModeIndex;
        }
        set
        {
            ShootingAnimation.OnShootingReady += SetShootingMode;
            shootingModeIndex = value == 0 ? 0 : 1;
        }
    }
    public void EnableFirepoint(int firepointIndex)
    {
        targetFirepointShooting.CurrentFirepoint = firepoints[firepointIndex];
        ShootingModeIndex = firepointIndex;
    }
    void SetShootingMode()
    {
        shootingAction.CurrentShootingMode = shootingModes[ShootingModeIndex];
    }
}