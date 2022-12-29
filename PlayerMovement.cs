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

    public delegate void PlayerAction(PlayerShootingManager shooting);
    public static event PlayerAction OnPlayerPressFireButton;

    bool IsWeaponReloaded
    {
        get
        {
            return playerShootingManager.HasPassedNecessaryTimeForShot;
        }
    }
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
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
        animator.SetBool("IsOnAir", false);
        //PlayerOnAirSM.OnAirAnimation += PlayerOnAir;
    }
    void PlayerOnAir(Animator targetAnimator)
    {
        targetAnimator.SetBool("IsOnAir", true);
        //PlayerOnAirSM.OnAirAnimation -= PlayerOnAir;
    }
    public void CheckVerticalSpeed(float verticalSpeed)
    {
        animator.SetFloat("VerticalSpeed", verticalSpeed);
    }
}
