using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirepointStateJumping : FirepointState
{
    GameObject jumpFirepoint;
    public GameObject JumpFirepoint
    {
        get
        {
            PlayerFallSM.OnBeginToFallSM -= PlayerBeginToFall;
            PlayerMovementSM.OnShooting -= JumpingFirepointShooting;
            return jumpFirepoint;
        }
        set
        {
            if (value != null)
            {
                PlayerFallSM.OnBeginToFallSM += PlayerBeginToFall;
                PlayerMovementSM.OnShooting += JumpingFirepointShooting;
            }
            else
            {
                CurrentFirepoint = JumpFirepoint;
            }
            jumpFirepoint = value;
        }
    }
    void PlayerBeginToFall()
    {
        JumpFirepoint = null;
    }
    void JumpingFirepointShooting()
    {
        ShootingFirepoint = JumpFirepoint;
        jumpFirepoint = null;
    }
}