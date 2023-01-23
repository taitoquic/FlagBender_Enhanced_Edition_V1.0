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
            return ExitJumpFirepoint;
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
                OnFirepointDisable -= EndJumping;
            }
            jumpFirepoint = value;
        }
    }
    GameObject ExitJumpFirepoint
    {
        get
        {
            OnFirepointDisable += EndJumping;
            return jumpFirepoint;
        }
    }
    void PlayerBeginToFall()
    {
        CurrentFirepoint = JumpFirepoint;
    }
    void JumpingFirepointShooting()
    {
        ShootingFirepoint = JumpFirepoint;
    }
    void EndJumping()
    {
        JumpFirepoint = null;
    }
}