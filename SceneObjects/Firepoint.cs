using UnityEngine;

public class Firepoint : MonoBehaviour
{
    public FPAction_Aiming fPAiming;
    public FPAction_Shooting fPShooting;
    FirepointAction[] fPActions;

    delegate void ActivateFpActions();
    ActivateFpActions OnFpActive;
    private void Awake()
    {
        fPActions = new FirepointAction[2] { fPAiming, fPShooting };
        //OnFpActive += AddFpActionsToEvents;
    }
    private void OnEnable()
    {
        OnFpActive?.Invoke();
    }
    private void OnDisable()
    {
        OnFpActive?.Invoke();
    }
    //void AddFpActionsToEvents()
    //{
    //    for (int i = 0; i < fPActions.Length; i++)
    //    {
    //        fPActions[i].AddToTargetEvent();
    //    }
    //    OnFpActive -= AddFpActionsToEvents;
    //    OnFpActive += RemoveFpActionsToEvents;
    //}
    //void RemoveFpActionsToEvents()
    //{
    //    for (int i = 0; i < fPActions.Length; i++)
    //    {
    //        fPActions[i].RemoveToTargetEvent();
    //    }
    //    OnFpActive -= RemoveFpActionsToEvents;
    //    OnFpActive += AddFpActionsToEvents;
    //}
    public void GenerateBulletToDirection(BulletTemplate bullet)
    {
        Instantiate(bullet.bulletPrefab, transform.position, transform.rotation);
    }
}