using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{

    public CharacterController controller;
    [SerializeField] public Animator animator;

    public AudioClip aJump;
    AudioSource audioSource;

    public float runSpeed = 40f;
    public float bounceForce;

    float horizontalMove = 0f;
    bool jump = false;
    //bool crouch = false;

    private Rigidbody2D rb;
    public float dashspeed;
    private float dashTime;
    public float startDashTime;
    private bool isDashing;
    private int counterDash;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        isDashing = false;
        counterDash = 0;
    }
    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetBool("isWalking", Convert.ToBoolean(Input.GetAxisRaw("Horizontal")));

        //jump
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
            audioSource.PlayOneShot(aJump, 0.5f);
        }

        //Dash
        if (Input.GetButtonDown("Fire3"))
        {
            isDashing = true;
            counterDash++;
   

        }

        else
        {
            if (dashTime < -0)
            {
                dashTime = startDashTime;
                isDashing = false;
            }
            else if (isDashing == true && counterDash < 2)
            {
                dashTime -= Time.deltaTime;
       
                rb.velocity = new Vector2(dashspeed * horizontalMove, rb.velocity.y);

            }
        }
    }

    public void OnLanding()
    {
        isDashing = false;
        counterDash = 0;
        jump = false;
        animator.SetBool("isJumping", false);
    }


    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, /*crouch,*/ jump);
    }
    public void EnemyKill()
    {
        rb.AddForce(new Vector2(0, bounceForce), ForceMode2D.Impulse );

    }
    
}