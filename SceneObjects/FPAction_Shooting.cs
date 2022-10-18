[System.Serializable]
public class FPAction_Shooting : FirepointAction
{
    public Firepoint currentFirepoint;
    public override void AddToTargetEvent()
    {
        PlayerShootingManager.OnPlayerShooting += currentFirepoint.GenerateBulletToDirection;
    }
    public override void RemoveToTargetEvent()
    {
        PlayerShootingManager.OnPlayerShooting -= currentFirepoint.GenerateBulletToDirection;
    }
}