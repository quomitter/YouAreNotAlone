using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.

    [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;   // How much to smooth out the movement
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform[] m_GroundCheck;                           // A position marking where to check if the player is grounded.
    [SerializeField] private Transform[] m_CeilingCheck;                          // A position marking where to check for ceilings


    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    public bool m_Grounded;            // Whether or not the player is grounded.

    public Rigidbody2D[] activePlayer;

    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;

  
    public Animator[] animator;


    //public AudioClip aJump;
    //AudioSource audioSource;

    public int bumperCounter = 0;

    [SerializeField] GameObject triggerPrefab;

    [SerializeField] Vector2 relativePositionToBuddy1;

    int jumpCounter;

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


    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    private void Awake()
    {
      
        jumpCounter = 0;

    }
    private void Start()
    {
        //audioSource = GetComponent<AudioSource>();

        activePlayer[0] = GetComponent<Rigidbody2D>();
        activePlayer[1] = GameObject.FindGameObjectWithTag("Buddy1").GetComponent<Rigidbody2D>();
        activePlayer[2] = GameObject.FindGameObjectWithTag("Buddy2").GetComponent<Rigidbody2D>();
        activePlayer[3] = GameObject.FindGameObjectWithTag("Buddy3").GetComponent<Rigidbody2D>();
        activePlayer[4] = GameObject.FindGameObjectWithTag("Buddy4").GetComponent<Rigidbody2D>();
        activePlayer[5] = GameObject.FindGameObjectWithTag("Buddy5").GetComponent<Rigidbody2D>();
        activePlayer[6] = GameObject.FindGameObjectWithTag("Buddy6").GetComponent<Rigidbody2D>();


        dashTime = startDashTime;
        isDashing = false;
        counterDash = 0;


        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }
    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator[bumperCounter].SetBool("isWalking", Convert.ToBoolean(Input.GetAxisRaw("Horizontal")));

        //jump
        if (jumpCounter < 2)
        {
            if (!jump)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    jump = true;
                    jumpCounter++;
                    animator[bumperCounter].SetBool("isJumping", true);
                    //audioSource.PlayOneShot(aJump, 0.5f);
                }
            }
        }
        else
        {
            jumpCounter = 0;

        }

        //Dash
        if (Input.GetButtonDown("Fire3"))
        {
            isDashing = true;
            counterDash++;
        }

        if (Input.GetButtonDown("LeftBumper"))
        {
            if (bumperCounter <= 6 && bumperCounter >= 0)
            {
                if(bumperCounter > 0)
                    bumperCounter--;
                else
                    bumperCounter = 6;
            }
        }
        if (Input.GetButtonDown("RightBumper"))
        {
            if (bumperCounter <= 6 && bumperCounter >= 0)
            {
                if (bumperCounter < 6)
                    bumperCounter++;
                else
                    bumperCounter = 0; 
            }
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

                activePlayer[bumperCounter].velocity = new Vector2(dashspeed * horizontalMove, activePlayer[bumperCounter].velocity.y);

            }
        }

    }


    public void OnLanding()
    {
        isDashing = false;
        counterDash = 0;
        jump = false;
        animator[bumperCounter].SetBool("isJumping", false);
    }


    void FixedUpdate()
    {
        // Move our character
        Move(horizontalMove * Time.fixedDeltaTime, /*crouch,*/ jump);

        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck[bumperCounter].position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
    }
    //public void EnemyKill()
    //{
    //    activePlayer[bumperCounter].AddForce(new Vector2(0, bounceForce), ForceMode2D.Impulse);

    //}
    public void Move(float move, /*bool crouch,*/ bool jump)
    {
        if (m_Grounded || m_AirControl)
        {

            Vector3 targetVelocity = new Vector2(move * 10f, activePlayer[bumperCounter].velocity.y);
            // And then smoothing it out and applying it to the character
            activePlayer[bumperCounter].velocity = Vector3.SmoothDamp(activePlayer[bumperCounter].velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
        }
        if (m_Grounded && jump)
        {
            // Add a vertical force to the player.
            m_Grounded = false;
            activePlayer[bumperCounter].AddForce(new Vector2(0f, m_JumpForce));
        }

    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = activePlayer[bumperCounter].transform.localScale;
        theScale.x *= -1;
        activePlayer[bumperCounter].transform.localScale = theScale;
    }
}