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
    float distanceToBeginOnAir = 2.0f;

    delegate void PlayerMoves();
    PlayerMoves OnPlayerBeginOnAir;
    PlayerMoves OnPlayerEndOnAir;

    public delegate void PlayerAction(PlayerShootingManager shooting);
    public static event PlayerAction OnPlayerPressFireButton;

    bool IsWeaponReloaded
    {
        get
        {
            return playerShootingManager.HasPassedNecessaryTimeForShot;
        }
    }
    Animator JumpMovement
    {
        get
        {
            OnPlayerEndOnAir -= EndJumping;
            return animator;
        }
        set
        {
            if (value != null)
            {
                value.SetBool("IsJumping", true);
                OnPlayerEndOnAir += EndJumping;
            }
        }
    }
    Animator LandMovement
    {
        get
        {
            OnPlayerBeginOnAir -= PlayerBeginOnAir;
            return animator;
        }
        set
        {
            if (value != null)
            {
                value.SetBool("IsOnAir", false);
                value.SetFloat("VerticalSpeed", 0);
                OnPlayerBeginOnAir += PlayerBeginOnAir;
            }
        }
    }
    Animator AirMovement
    {
        get
        {
            OnPlayerEndOnAir -= PlayerEndOnAir;
            return animator;
        }
        set
        {
            if (value != null)
            {
                value.SetBool("IsOnAir", true);
                OnPlayerEndOnAir += PlayerEndOnAir;
            }
        }
    }
    private void Start()
    {
        OnPlayerEndOnAir = PlayerEndOnAir;
    }
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
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
        OnPlayerEndOnAir?.Invoke();
    }
    public void PlayerJump()
    {
        JumpMovement = animator;
    }
    public void CheckVerticalSpeed(float verticalSpeed)
    {
        if (verticalSpeed < -distanceToBeginOnAir || verticalSpeed > distanceToBeginOnAir) 
        {
            animator.SetFloat("VerticalSpeed", verticalSpeed);
            OnPlayerBeginOnAir?.Invoke();
        }
    }
    void PlayerEndOnAir()
    {
        LandMovement = AirMovement;
    }
    void PlayerBeginOnAir()
    {
        AirMovement = LandMovement;
    }
    void EndJumping()
    {
        JumpMovement.SetBool("IsJumping", false);
    }
}