using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UlquiorraScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private int countJump = 0;
    private float xInput;
    private bool facingRight = true;
    private bool isShooting = false;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    [Header("Collision Check")]
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask whatIsGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        HandleInput();
        CheckCollison();
        AnimationController();
        FlipController();

        if (!isShooting)
        {
            Move();
        }
    }

    private void AnimationController()
    {
        anim.SetFloat("xVelocity", rb.velocity.x);
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W)) Jump();
    }

    private void Move()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveSpeed * xInput, rb.velocity.y);
    }

    private void Jump()
    {
        if (isGrounded || countJump < 1)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            countJump++;
        }
    }

    private void CheckCollison()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (isGrounded)
        {
            countJump = 0;
        }
    }

    private void FlipController()
    {
        if (rb.velocity.x < 0 && facingRight)
        {
            Flip();
        }
        else if (rb.velocity.x > 0 && !facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
