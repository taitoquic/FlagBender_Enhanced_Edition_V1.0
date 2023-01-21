using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    ShootingAction playerShootingMode = new ShootingActionStayable();
    public ShootingAction PlayerShootingMode
    {
        get
        {
            return playerShootingMode;
        }
    }
    private void Awake()
    {
        instance = this;
    }
    [Header("Board Managers")]
    [Space]
    public FirepointsManager firepointsManager;
    public FirepointTargetableManager firepointTargetableManager;
}
