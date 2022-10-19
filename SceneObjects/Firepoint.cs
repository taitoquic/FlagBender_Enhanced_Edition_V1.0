using UnityEngine;

public abstract class Firepoint : MonoBehaviour
{
    public abstract bool IsFirepointEnabled { set; }

    private void OnEnable()
    {
        IsFirepointEnabled = gameObject.activeInHierarchy;
    }
    private void OnDisable()
    {
        IsFirepointEnabled = gameObject.activeInHierarchy;
    }
    public abstract void FirepointDirectionTo<T>(T firepointAction) /*where T : ActionAiming*/;
}