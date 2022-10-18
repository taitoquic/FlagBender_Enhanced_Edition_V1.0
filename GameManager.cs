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
    [Header("State Machines Managers")]
    [Space]

    public SMShootingManager sMShootingManager;
    [Header("Scene Managers")]
    [Space]
    public SceneTransformsManager sceneTransformsManager;
}
