using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public PlayerShootingManager playerShootingManager;
    public Animator animator;
    public float runSpeed = 25f;
    float horizontalMove = 0f;
    bool jump = false;
    bool canJump = true;
    float distanceToBeginOnAir = 2.0f;

    public delegate void PlayerMoves();
    public static event PlayerMoves OnButtonUpFireButton;
    PlayerMoves OnPlayerHoldFireButton;
    PlayerMoves OnPlayerUpFireButton;
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
    float RunSpeed
    {
        get
        {
            return 25;
        }
    }
    PlayerShootingManager PlayerMakesAShot
    {
        set
        {
            if (value != null)
            {
                OnPlayerPressFireButton?.Invoke(value);
            }
        }
    }
    PlayerShootingManager PlayerMakeAShot
    {
        get
        {
            OnPlayerHoldFireButton?.Invoke();
            return playerShootingManager;
        }
    }
    
    Animator PlayerBeforeShooting
    {
        get
        {
            OnPlayerHoldFireButton -= PlayerFireButtonHolded;
            return animator;
        }
        set
        {
            if (value != null)
            {
                OnPlayerHoldFireButton += PlayerFireButtonHolded;
            }
        }
    }
    Animator FireButtonHolded
    {
        get
        {
            OnPlayerUpFireButton -= PlayerUpFireButton;
            FirepointActivableSM.OnEnterMovementSM -= PlayerFireButtonHoldedAfterShooting;
            return animator;
        }
        set
        {
            if (value != null)
            {
                value.SetBool("IsHoldingFireButton", true);
                OnPlayerUpFireButton += PlayerUpFireButton;
                FirepointActivableSM.OnEnterMovementSM += PlayerFireButtonHoldedAfterShooting;
            }
        }
    }
    Animator FireButtonUp
    {
        get
        {
            FirepointActivableSM.OnEnterMovementSM -= PlayerResetFirstShot;
            return animator;
        }
        set
        {
            if (value != null)
            {
                value.SetBool("IsHoldingFireButton", false);
                OnButtonUpFireButton?.Invoke();
                FirepointActivableSM.OnEnterMovementSM += PlayerResetFirstShot;
            }
        }
    }
    Animator FireButtonUpCancelled
    {
        set
        {
            if (value != null)
            {
                value.SetBool("IsHoldingFireButton", false);
                PlayerBeforeShooting = value;
            }
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
        PlayerBeforeShooting = animator;
    }
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = canJump;
        }
        if (Input.GetButtonDown("Fire1") && IsWeaponReloaded)
        {
            PlayerMakesAShot = PlayerMakeAShot;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            OnPlayerUpFireButton?.Invoke();
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
    void PlayerFireButtonHolded()
    {
        FireButtonHolded = PlayerBeforeShooting;
    }
    void PlayerUpFireButton()
    {
        FireButtonUp = FireButtonHolded;
    }
    void PlayerResetFirstShot()
    {
        PlayerBeforeShooting = FireButtonUp;
    }
    void PlayerFireButtonHoldedAfterShooting()
    {
        FireButtonUpCancelled = FireButtonHolded;
    }
    public void PlayerStopMove()
    {
        runSpeed = 0;
        canJump = false;
    }
    public void PlayerResumeMove()
    {
        runSpeed = RunSpeed;
        canJump = true;
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
    public void SetActiveBolterChargable(bool isActive)
    {
        animator.SetBool("IsBolterChargable", isActive);
    }
}