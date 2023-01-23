using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallSM : PlayerOnAirSM
{
    public static event MovementAction OnBeginToFallSM;
    public override Animator CurrentAnimator
    {
        set
        {
            OnBeginToFallSM?.Invoke();
            base.CurrentAnimator = value;
        }
    }
}