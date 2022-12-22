using UnityEngine;

public class Firepoint : MonoBehaviour
{
    public delegate void FirepointAction(Transform currentTransform);
    public static event FirepointAction OnFirepointAction;
    private void OnEnable()
    {
        OnFirepointAction?.Invoke(transform);
    }
}