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

    bool IsWeaponReloaded
    {
        get
        {
            return playerShootingManager.shooting.HasPassedNecessaryTimeForShot;
        }
    }
    //bool IsShootingTriggerOn
    //{
    //    set
    //    {
    //        if (value)
    //        {
    //            animator.SetTrigger("Shooting");
    //        }
    //        playerShooting.Shoot();
    //    }
    //}
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
            animator.SetTrigger("Shooting");
            playerShootingManager.Shot();
            //IsShootingTriggerOn = !playerShooting.IsShootingInSameMovement;
        }
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
    public void PlayerBeginOnAir()
    {
        animator.SetBool("OnAir", true);
    }
    public void PlayerLanding()
    {
        animator.SetBool("OnAir", false);
    }
    public void CheckVerticalSpeed(float verticalSpeed)
    {
        animator.SetFloat("VerticalSpeed", verticalSpeed);
    }
    //void BeginShot()
    //{
    //    playerShootingManager.Shot();
    //}
}
