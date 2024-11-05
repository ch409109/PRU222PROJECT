using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPlayer : MonoBehaviour
{
	[SerializeField] float forceX, forceY;
	float xInput;
	[SerializeField] Sprite newSprite; 

	private SpriteRenderer spriteRenderer;

	[Header("Ground check")]
	[SerializeField] float groundCheckRadius;
	[SerializeField] Transform groundCheck;
	[SerializeField] LayerMask groundMask;
	bool isGround;
	bool facingRight = true;
	bool isMoving = false;
	bool isDead = false;
	Rigidbody2D rb;
	Animator animator;
	// Start is called before the first frame update
	void Start()
    {
		rb = gameObject.GetComponent<Rigidbody2D>();
		animator = gameObject.GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    void Update()
    {
		CollisionCheck();
		xInput = Input.GetAxisRaw("Horizontal_P2");
		Movement();
		Flip();
		if (Input.GetKeyDown(KeyCode.Keypad5))
		{
			Jump();

		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
		}
		AnimatorController();
	}

	private void AnimatorController()
	{
		
	}

	private void Movement()
	{
		rb.velocity = new Vector2(xInput * forceX, rb.velocity.y);
		animator.SetBool("IsMoving", true);
	}
	private void Jump()
	{
		if (isGround)
		{
			rb.velocity = new Vector2(rb.velocity.x, forceY);
		}
	}
	private void Flip()
	{
		if (rb.velocity.x < 0 && facingRight)
		{
			facingRight = !facingRight;
			transform.Rotate(0, 180, 0);
		}
		else if (rb.velocity.x > 0 && !facingRight)
		{
			facingRight = !facingRight;
			transform.Rotate(0, 180, 0);
		}

	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(groundCheck.transform.position, groundCheckRadius);
	}
	private void CollisionCheck()
	{
		isGround = Physics2D.OverlapCircle(groundCheck.transform.position, groundCheckRadius, groundMask);
	}
}
