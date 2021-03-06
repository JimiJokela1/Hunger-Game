﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(GrandmaProperties))]
public class GrandmaMovement : MonoBehaviour
{

    public enum Directions {Up, Down, Right, Left};
    public Directions directions;

    public bool facingRight = true;

	static GrandmaMovement _instance;
	public static GrandmaMovement Instance
	{
		get
		{
			return _instance = _instance ?? FindObjectOfType<GrandmaMovement>();
		}
	}

	private GrandmaProperties _properties;
	public GrandmaProperties Properties
	{
		get { return _properties = _properties ?? GetComponent<GrandmaProperties>(); }
	}

    public float moveSpeed = 1f;
    public float jumpDistance = 3f;
    public float jumpTime = 1f;
    public AudioSource moveAudioSource;
    public AudioSource jumpAudioSource;

    private Vector2 currentMovementInput;
    private Rigidbody2D rb;

    private Animator animator;

    private bool jumping = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private Vector2 GetMovementInput()
    {
        Vector2 input = new Vector2();
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
        return Vector2.ClampMagnitude(input, 1f);
    }

    private bool GetJumpInput()
    {
        return Input.GetButtonDown("Jump");
    }

    private void Update()
    {
        currentMovementInput = GetMovementInput();
    }

    private void FixedUpdate()
    {
        // Movement
        if (currentMovementInput != null && currentMovementInput != Vector2.zero)
        {
            // Move with momentum
            // rb.AddForce(currentInput * moveSpeed, ForceMode2D.Force);

            // Move without momentum
            rb.MovePosition(rb.position + currentMovementInput * moveSpeed * Time.fixedDeltaTime);

            var angle = Vector2.SignedAngle(Vector2.up, currentMovementInput);
          

            if (angle == 0)
                directions = Directions.Up;

            if (angle == 180)
                directions = Directions.Down;


            if (angle == -90)
                directions = Directions.Right;

            if (angle == 90)
                directions = Directions.Left;



            if (directions == Directions.Up)
            {
                animator.SetInteger("Index", 0);
            }
            else if (directions == Directions.Down)
            {
                animator.SetInteger("Index", 1);
            }
            else if (directions == Directions.Right)
            {
                animator.SetInteger("Index", 2);
            }
            else if (directions == Directions.Left)
            {
                animator.SetInteger("Index", 3);
            }

            // Set move animation
            //if (animator != null)
            //{
            //    animator.SetBool("Moving", true);
            //}

            // Set move sound
            //if (moveAudioSource != null && !moveAudioSource.isPlaying)
            //{
            //    moveAudioSource.Play();
            //}

            //// Jumping, can only jump when moving
            //if (GetJumpInput() && jumping == false)
            //{
            //    TryJumpOverCollider(currentMovementInput.normalized);
            //}
        }
        else // not moving
        {
            StopMoving();
        }
    }

    private void TryJumpOverCollider(Vector2 direction)
    {
        LayerMask layerMask = ~(1 << LayerMask.NameToLayer("Player"));
        RaycastHit2D hit = Physics2D.Raycast(rb.position, direction, jumpDistance, layerMask);

        if (hit.collider != null)
        {
            jumping = true;
            StopMoving();

            // Set jump animation
            if (animator != null)
            {
                animator.SetBool("Jumping", true);
            }

            // Play jump sound
            if (jumpAudioSource != null)
            {
                jumpAudioSource.Play();
            }

            StartCoroutine(JumpSequence(direction));
        }
    }

    IEnumerator JumpSequence(Vector2 direction)
    {
        yield return new WaitForSeconds(jumpTime);
        rb.position = (rb.position + direction * jumpDistance);
        jumping = false;
    }

    private void StopMoving()
    {
        // Set move animation
        if (animator != null)
        {
            animator.SetBool("Moving", false);
        }

        // Set move sound
        if (moveAudioSource != null && moveAudioSource.isPlaying)
        {
            moveAudioSource.Stop();
        }
    }
}
