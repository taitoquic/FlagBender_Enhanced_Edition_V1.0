using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingStand : MonoBehaviour
{
    public void OnEnterShootingState()
    {
        PlayerShootingManager.OnPlayerShooting += ShootingInState;
        PlayerAiming.OnNewMovementState += RemoveShotingInState;
        PlayerShootingSM.OnEndShotAction += RemoveShotingInState;
    }
    public virtual void ShootingInState(Transform[] firepoints, PlayerMovementAction_Shooting shooting)
    {
        shooting.CalculateTimeForNextShot();
    }
    public virtual void RemoveShotingInState()
    {
        PlayerShootingManager.OnPlayerShooting -= ShootingInState;
        PlayerAiming.OnNewMovementState -= RemoveShotingInState;
        PlayerShootingSM.OnEndShotAction -= RemoveShotingInState;
    }
}
