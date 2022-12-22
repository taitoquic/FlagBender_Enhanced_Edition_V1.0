using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    [Header("Board Managers")]
    [Space]
    public FirepointsManager firepointsManager;
    public FirepointTargetableManager firepointTargetableManager;
}
