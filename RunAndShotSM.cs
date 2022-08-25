using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OnAirShotSM;

public class RunAndShotSM : StateMachineBehaviour
{
    public delegate void RunAndShotAction();
    public static event RunAndShotAction OnRunAndShotAction;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnRunAndShotAction?.Invoke();
        Debug.Log(OnRunAndShotAction);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnRunAndShotAction?.Invoke();
    }

}
