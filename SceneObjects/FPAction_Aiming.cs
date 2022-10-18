using UnityEngine;

[System.Serializable]
public class FPAction_Aiming: FirepointAction
{
    public Transform targetTransform;

    public override void AddToTargetEvent()
    {
        PlayerAiming.OnPlayerAiming += PlayerAimingToDirection;
    }
    void PlayerAimingToDirection(ActionAiming aiming)
    {
        targetTransform.right = aiming.CalculateNewTransformRight(targetTransform);
        aiming.MoveAimToDistance(targetTransform);
    }
    public override void RemoveToTargetEvent()
    {
        PlayerAiming.OnPlayerAiming -= PlayerAimingToDirection;
    }
}