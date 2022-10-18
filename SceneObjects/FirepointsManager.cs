using UnityEngine;

public class FirepointsManager : MonoBehaviour
{
    public GameObject[] firepoints = new GameObject[3];
    GameObject currentFirepoint;
    public int CurrentFirepointIndex
    {
        set
        {
            CurrentFirepoint = firepoints[value];
        }
    }
    public GameObject CurrentFirepoint
    {
        get
        {
            return currentFirepoint;
        }
        set
        {
            if (value != null)
            {
                value.SetActive(true);
            }
            currentFirepoint = value;
        }
    }
}