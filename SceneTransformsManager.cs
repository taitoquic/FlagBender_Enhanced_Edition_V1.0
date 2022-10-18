using UnityEngine;

public class SceneTransformsManager : MonoBehaviour
{
    public FirepointsManager firepointsManager;

    public delegate void FirepointAction(FirepointsManager firepointsManager);
    public static event FirepointAction OnChangeFirepoint;

    public int CurrentSMIndex
    {
        set
        {
            OnChangeFirepoint?.Invoke(firepointsManager);
            firepointsManager.CurrentFirepointIndex = value;
        }
    }
}