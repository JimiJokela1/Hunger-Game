using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GrandmaMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public AudioSource moveAudioSource;

    private Vector2 currentInput;
    private Rigidbody2D rb;

    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private Vector2 GetInput()
    {
        Vector2 input = new Vector2();
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
        return Vector2.ClampMagnitude(input, 1f);
    }

    private void Update()
    {
        currentInput = GetInput();
    }

    private void FixedUpdate()
    {
        if (currentInput != null && currentInput != Vector2.zero)
        {
            // Move with momentum
            // rb.AddForce(currentInput * moveSpeed, ForceMode2D.Force);
            
            // Move without momentum
            rb.MovePosition(rb.position + currentInput * moveSpeed * Time.fixedDeltaTime);

            // Set move animation
            if (animator != null)
            {
                animator.SetBool("Moving", true);
            }

            // Set move sound
            if (moveAudioSource != null && !moveAudioSource.isPlaying)
            {
                moveAudioSource.Play();
            }
        }
        else // not moving
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
}
