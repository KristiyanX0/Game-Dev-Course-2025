using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float horizontal;
    Animator animator;
    [SerializeField] float speed;
    [SerializeField] float transitionDuration = 0.5f; // Global value for transition duration

    [SerializeField] String platformNameTag = "Platform";

    void Start()
    {
        horizontal = 0;
        speed = 0;
        animator = GetComponent<Animator>();
        CheckForErrors();
    }

    void CheckForErrors()
    {
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
    }

    void UpdateMovement()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                speed = 4;
            }
            else
            {
                speed = 2;
            }
        } else {
            speed = 0;
        }

        float normalizedSpeed = Mathf.InverseLerp(0, 4, speed);
        animator.SetFloat("normalizedSpeed", normalizedSpeed);
    }

    void FixedUpdate() {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
}
