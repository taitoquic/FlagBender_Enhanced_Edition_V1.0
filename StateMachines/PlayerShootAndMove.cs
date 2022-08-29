using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootAndMove : PlayerMovementSM
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        PlayerShooting.OnTriggerInMovement += ShotInState;
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        OnMovementStateAction += StopShotInState;
    }
    void ShotInState(GameObject bulletPrefab, Transform[] firepoints)
    {
        Instantiate(bulletPrefab, firepoints[movementStateIndex].position, firepoints[movementStateIndex].rotation);
    }
    void StopShotInState()
    {
        PlayerShooting.OnTriggerInMovement -= ShotInState;
        OnMovementStateAction -= StopShotInState;
    }
}
