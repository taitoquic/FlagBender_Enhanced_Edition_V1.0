using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<IInitializable> initializables = new List<IInitializable>();
    public ShootingAction playerShootingMode = new ShootingActionStayable();
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        initializableFeature.CurrentInitializables = initializables;
    }
    [Header("Scene Managers")]
    [Space]
    public FirepointsManager firepointsManager;
    [Header("Features")]
    [Space]
    public InitializableFeature initializableFeature;
}