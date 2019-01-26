﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GrandmaMovement : MonoBehaviour
{
    public float moveSpeed = 1f;

    private Vector2 currentInput;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
        if (currentInput != null)
        {
            // rb.AddForce(currentInput * moveSpeed, ForceMode2D.Force);
            rb.MovePosition(rb.position + currentInput * moveSpeed * Time.fixedDeltaTime);
        }
    }
}