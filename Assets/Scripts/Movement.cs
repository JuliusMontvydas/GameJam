﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : UnityEngine.MonoBehaviour {
    public float speed;
    public float jumpVelocity;
    public float lowJumpMultiplier = 2f;
    public float fallMultiplier = 2.5f;
    public float maxFallSpeed = 100f;
    private bool jumpRequest;
    private Rigidbody2D player;

    // RP functionality TODO: comment
    public bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 2.5f;
    public LayerMask whatIsGround;

	// Used for animations
	public bool facingRight;
	private float horizontal;

	private Animator animator;
	private float speedBeforeTick;
	private bool canSlide;

	void Awake()
	{
		player = GetComponent<Rigidbody2D>();

		// Used for Animations
		Vector3 scale = transform.localScale;

		facingRight = scale.x > 0;
		animator = GetComponent<Animator>();
		speedBeforeTick = 0;

		resetDefaults();
	}

	public void resetDefaults()
	{
		// Mechanics
		speed = 80;
		jumpVelocity = 120;
	}

	void Update () {
        // Horizontal movement
        player.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, player.velocity.y);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpRequest = true;
        }

        //Less floatyness
        if (player.velocity.y < 0)
        {
            player.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (player.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            player.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		float horizontal = Input.GetAxis("Horizontal");
		Flip(horizontal);

		// Set speed for animations
		float speed = Mathf.Abs(player.velocity.x);
		float fallingSpeed = Mathf.Abs(player.velocity.y);
		animator.SetFloat("speed", speed);

		animator.SetFloat("horiz", Mathf.Abs(Input.GetAxis("Horizontal")));

		// Checks if speed is decading and acceleration
		bool speadIsDecading = speedBeforeTick > speed;
		bool speadIsAccelerating = speedBeforeTick < speed;
		animator.SetBool("speedIsDecading", speadIsDecading);

		// Checks if can slide
		if (speadIsAccelerating) 
{			if (speed >= 80)
			{
				canSlide = true;
			} else
			{
				canSlide = false;
			}
		}
		animator.SetBool("canSlide", canSlide);

		speedBeforeTick = speed;


		// Checks if in the air and not jumping
		animator.SetBool("isInAir", fallingSpeed > 7);



		if (jumpRequest && grounded)
        {
            player.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
            jumpRequest = false;
        }

        if(player.velocity.magnitude > maxFallSpeed)
        {
            //player.velocity = player.velocity.normalized * maxFallSpeed;
        }
    }

	private void Flip(float horizontal)
	{
		if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
		{
			facingRight = !facingRight;
	
			//Gets AnimatedPlayer element's scale
			Vector3 scale = transform.localScale;

			//Takes scales X value and makes it opposite
			scale.x *= -1;

			transform.localScale = scale;
		}
	}
}
