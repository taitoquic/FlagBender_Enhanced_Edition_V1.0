using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public PlayerShootingManager playerShootingManager;
    public Animator animator;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;

    delegate void PlayerMoves();
    PlayerMoves OnJumpLanding;

    public delegate void PlayerAction(PlayerShootingManager shooting);
    public static event PlayerAction OnPlayerPressFireButton;

    bool IsWeaponReloaded
    {
        get
        {
            return playerShootingManager.HasPassedNecessaryTimeForShot;
        }
    }
    bool Jump
    {
        get
        {
            OnJumpLanding -= EndJumping;
            return jump;
        }
        set
        {
            if (value)
            {
                animator.SetBool("IsJumping", value);
                OnJumpLanding += EndJumping;
            }
            jump = value;
        }      
    }
    bool PlayerOnAir
    {
        get
        {
            animator.SetFloat("VerticalSpeed", 0);
            OnJumpLanding?.Invoke();
            return false;
        }
    }
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            Jump = true;
        }
        if (Input.GetButtonDown("Fire1") && IsWeaponReloaded)
        {
            OnPlayerPressFireButton?.Invoke(playerShootingManager);
        }
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
    public void PlayerLanding()
    {
        animator.SetBool("IsOnAir", PlayerOnAir);
    }
    public void CheckVerticalSpeed(float verticalSpeed)
    {
        if (verticalSpeed < -2 || verticalSpeed > 2)
        {
            animator.SetFloat("VerticalSpeed", verticalSpeed);
            animator.SetBool("IsOnAir", true);
        }
    }
    void EndJumping()
    {
        animator.SetBool("IsJumping", Jump);
    }
}
