using UnityEngine;

public class Player_Controller : MonoBehaviour {
	private Rigidbody2D rb;
	private bool isJumping = false;
	public float maxSpeed = 50f;
	public float jumpHeight = 2.0f;

	void Start(){
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		PerformRunAndJump();
	}

	private void PerformRunAndJump()
	{
		if (Input.GetKey("q")) // the input for the character to go left
		{
			if (transform.localScale.x > 0) // if transform.localScale.x is positive, the sprite faces right
			{
				transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y); // transform.localScale.x is set to negative, the sprite faces left
			}
			if (maxSpeed > 0) // if maxSpeed is positive, the character will go right
			{
				maxSpeed *= -1; // maxSpeed is set to negative, the character go left
			}
			rb.velocity = new Vector2(maxSpeed * Time.deltaTime, rb.velocity.y);
		}
		if (Input.GetKey("d")) // the input for the character to go right
		{
			if (transform.localScale.x < 0) // if transform.localScale.x is negative, the sprite faces left
			{
				transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y); // transform.localScale.x is set to positive, the sprite faces right
			}
			if (maxSpeed < 0) // if maxSpeed is negative, the character will go left
			{
				 maxSpeed *= -1; // maxSpeed is set to positive, the character go right
			}
			rb.velocity = new Vector2(maxSpeed * Time.deltaTime, rb.velocity.y);
		}

		if (Input.GetKeyDown("space") && !isJumping)
		{
			isJumping = true;
			rb.AddForce(Vector2.up * jumpHeight);
			isJumping = false;
		}
	}
}