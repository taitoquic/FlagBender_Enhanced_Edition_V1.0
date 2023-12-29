using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<IInitializable> initializables = new List<IInitializable>();
    public ShootingAction playerShootingMode = new ShootingActionStayable();
    public List<IInitializable> Initializables
    {
        get
        {
            InitializableFeature.OnEndInitializables -= EndInitializable;
            initializableFeature = null;
            return null;
        }
        set
        {
            InitializableFeature.OnEndInitializables += EndInitializable;
            initializableFeature.CurrentInitializables = value;
        }
    }
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Initializables = initializables;
    }
    [Header("Scene Managers")]
    [Space]
    public FirepointsManager firepointsManager;
    [Header("Features")]
    [Space]
    public InitializableFeature initializableFeature;
    public ChargableFeature chargableFeature;
    void EndInitializable()
    {
        initializables = Initializables;
    }
}