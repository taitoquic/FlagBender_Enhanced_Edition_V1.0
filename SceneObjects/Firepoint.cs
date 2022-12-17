using UnityEngine;

public class Firepoint : MonoBehaviour
{
    public delegate void FirepointAction(Transform currentTransform);
    public static event FirepointAction OnFirepointAction;

    public delegate void FirepointDisableAction();
    public static event FirepointDisableAction OnFirepointDisable;
    private void OnEnable()
    {
        OnFirepointAction?.Invoke(transform);
    }
    private void OnDisable()
    {
        OnFirepointDisable?.Invoke();
    }
}