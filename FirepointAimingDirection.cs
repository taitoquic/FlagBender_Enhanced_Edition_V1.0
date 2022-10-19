using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirepointAimingDirection : Firepoint
{
    public override bool IsFirepointEnabled
    {
        set
        {
            if (value)
            {
                //PlayerAiming.OnPlayerAiming += PlayerAimingToDirection;
            }
            else
            {
                //PlayerAiming.OnPlayerAiming -= PlayerAimingToDirection;
            }
        }
    }
    public override void FirepointDirectionTo<ActionAiming>(ActionAiming firepointAction)
    {
        //transform.right = firepointAction.CalculateNewTransformRight(transform);
        //firepointAction.MoveAimToDistance(transform);
        
    }
}
