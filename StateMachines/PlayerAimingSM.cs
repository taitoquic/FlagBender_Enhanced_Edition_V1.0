using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimingSM : StateMachineBehaviour
{
    public int stateIndex;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameManager.instance.sceneTransformsManager.CurrentSMIndex = stateIndex;
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SceneTransformsManager.OnChangeFirepoint += ChangeFirepoint;
    }
    void ChangeFirepoint(FirepointsManager firepointsManager)
    {
        firepointsManager.CurrentFirepoint.SetActive(false);
        SceneTransformsManager.OnChangeFirepoint -= ChangeFirepoint;
    }
}
