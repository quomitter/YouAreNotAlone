using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{

    public CharacterController controller;
    [SerializeField] public Animator animator;

    public AudioClip aJump;
    AudioSource audioSource;

    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] Rigidbody2D buddy1;
    [SerializeField] Rigidbody2D buddy2;
    [SerializeField] Rigidbody2D buddy3;
    [SerializeField] Rigidbody2D buddy4;
    [SerializeField] Rigidbody2D buddy5;
    [SerializeField] Rigidbody2D buddy6;

    [SerializeField] Vector2 playerLastPosition;
    [SerializeField] Vector2 Buddy1LastPosition;
    [SerializeField] Vector2 Buddy2LastPosition;
    [SerializeField] Vector2 Buddy3LastPosition;
    [SerializeField] Vector2 Buddy4LastPosition;
    [SerializeField] Vector2 Buddy5LastPosition;
    [SerializeField] Vector2 Buddy6LastPosition;

    float distanceFromPlayer;
    float distanceFromBuddy1;
    float distanceFromBuddy2;
    float distanceFromBuddy3;
    float distanceFromBuddy4;
    float distanceFromBuddy5;
    float distanceFromBuddy6;

    Vector2 playerJumpPoint;

    float step;

    public float runSpeed = 40f;
    public float bounceForce;

    float horizontalMove = 0f;
    bool jump = false;
    //bool crouch = false;

   
    public float dashspeed;
    private float dashTime;
    public float startDashTime;
    private bool isDashing;
    private int counterDash;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();


        playerRb = GetComponent<Rigidbody2D>();
        buddy1 = GameObject.FindGameObjectWithTag("Buddy1").GetComponent<Rigidbody2D>();
        buddy2 = GameObject.FindGameObjectWithTag("Buddy2").GetComponent<Rigidbody2D>();
        buddy3 = GameObject.FindGameObjectWithTag("Buddy3").GetComponent<Rigidbody2D>();
        buddy4 = GameObject.FindGameObjectWithTag("Buddy4").GetComponent<Rigidbody2D>();
        buddy5 = GameObject.FindGameObjectWithTag("Buddy5").GetComponent<Rigidbody2D>();
        buddy6 = GameObject.FindGameObjectWithTag("Buddy6").GetComponent<Rigidbody2D>();


        dashTime = startDashTime;
        isDashing = false;
        counterDash = 0;
    }
    // Update is called once per frame
    void Update()
    {
        step = 10f * Time.deltaTime;

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetBool("isWalking", Convert.ToBoolean(Input.GetAxisRaw("Horizontal")));

        //jump
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
            audioSource.PlayOneShot(aJump, 0.5f);
            playerJumpPoint = playerRb.position;

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
       
                playerRb.velocity = new Vector2(dashspeed * horizontalMove, playerRb.velocity.y);

            }
        }

        //FollowCode

        distanceFromPlayer = Vector2.Distance(playerRb.position, buddy1.position);
        distanceFromBuddy1 = Vector2.Distance(buddy1.position, buddy2.position);
        distanceFromBuddy2 = Vector2.Distance(buddy2.position, buddy3.position);
        distanceFromBuddy3 = Vector2.Distance(buddy3.position, buddy4.position);
        distanceFromBuddy4 = Vector2.Distance(buddy4.position, buddy5.position);
        distanceFromBuddy5 = Vector2.Distance(buddy5.position, buddy6.position);
        //distanceFromBuddy6 = Vector2.Distance(buddy6.position, buddy2.position);

        
        if(distanceFromPlayer > 2f) 
        {
            buddy1.transform.position = Vector2.MoveTowards(buddy1.position, playerRb.position, step);
            if(buddy1.position == playerJumpPoint)
            {
                buddy1.AddForce(new Vector2(0f, 400f));
            }
        }
        else if(distanceFromPlayer < 2f)
        {
            buddy1.velocity = Vector2.zero;
        }

        if (distanceFromBuddy1 > 2f)
        {
            buddy2.transform.position = Vector2.MoveTowards(buddy2.position, buddy1.position, step);
            if (buddy2.position == playerJumpPoint)
            {
                buddy2.AddForce(new Vector2(0f, 400f));
            }
        }
        else if (distanceFromBuddy1 < 2f)
        {
            buddy2.velocity = Vector2.zero;
        }

        if (distanceFromBuddy2 > 2f)
        {
            buddy3.transform.position = Vector2.MoveTowards(buddy3.position, buddy2.position, step);
            if (buddy3.position == playerJumpPoint)
            {
                buddy3.AddForce(new Vector2(0f, 400f));
            }
        }
        else if (distanceFromBuddy2 < 2f)
        {
            buddy3.velocity = Vector2.zero;
        }
        if (distanceFromBuddy3 > 2f)
        {
            buddy4.transform.position = Vector2.MoveTowards(buddy4.position, buddy3.position, step);
            if (buddy4.position == playerJumpPoint)
            {
                buddy4.AddForce(new Vector2(0f, 400f));
            }
        }
        else if (distanceFromBuddy3 < 2f)
        {
            buddy4.velocity = Vector2.zero;
        }
        if (distanceFromBuddy4 > 2f)
        {
            buddy5.transform.position = Vector2.MoveTowards(buddy5.position, buddy4.position, step);
            if (buddy5.position == playerJumpPoint)
            {
                buddy5.AddForce(new Vector2(0f, 400f));
            }
        }
        else if (distanceFromBuddy4 < 2f)
        {
            buddy5.velocity = Vector2.zero;
        }
        if (distanceFromBuddy5 > 2f)
        {
            buddy6.transform.position = Vector2.MoveTowards(buddy6.position, buddy5.position, step);
            if (buddy6.position == playerJumpPoint)
            {
                buddy6.AddForce(new Vector2(0f, 400f));
            }
        }
        else if (distanceFromBuddy5 < 2f)
        {
            buddy6.velocity = Vector2.zero;
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
        playerRb.AddForce(new Vector2(0, bounceForce), ForceMode2D.Impulse );

    }
    
}