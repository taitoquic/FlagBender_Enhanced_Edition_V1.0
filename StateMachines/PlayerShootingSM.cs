using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerShootingSM : StateMachineBehaviour
{
    public abstract int ShootingStateIndex { get; }

    //public delegate void StateAction(int stateIndex);
    //public static event StateAction OnStateAction;

    public delegate void PlayerShotAction();
    public static event PlayerShotAction OnShotAction;

    //bool CanShotInState
    //{
    //    get
    //    {
    //        OnShotAction?.Invoke();
    //        OnShotAction += StopShootingInState;
    //        Debug.Log("hola");
    //        return ShootingStateIndex != 0;
    //    }
    //}

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnShotAction?.Invoke();
        //if(CanShotInState) PlayerShooting.OnTriggerInMovement += ShotInState;
        //OnStateAction?.Invoke(ShootingStateIndex);
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnShotAction?.Invoke();
    }
    //void ShotInState(GameObject bulletPrefab, Transform[] firepoints)
    //{
    //    Instantiate(bulletPrefab, firepoints[ShootingStateIndex].position, firepoints[ShootingStateIndex].rotation);
    //}
    //void StopShootingInState()
    //{
    //    PlayerShooting.OnTriggerInMovement -= ShotInState;
    //}
}
