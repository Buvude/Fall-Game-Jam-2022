using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float HorizontalVelocityAccelerate = 0.2f;
	public float HorizontalVelocityDecccelerate = 0.5f;
	public float MaxHorizontalVelocity = 3.5f;
	public float JumpVelocity = 5f;
	float MoveVelocityAccel = 0f;
	bool isJumping = false;

	public Transform playerSpriteTransform;
	public Sprite playerSprite;

	void Update()
	{
        	if (Input.GetButtonDown("Jump") && GetComponent<Rigidbody2D>().velocity.y < 0.01f && !isJumping)
        	{
	        	GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,JumpVelocity/GetComponent<Rigidbody2D>().mass),ForceMode2D.Impulse);
        	}
		float dirMult = 1;
		if (Input.GetAxis("Horizontal") < 0)
		{
			dirMult = -1;
		}
        	if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.01f)
		{
			MoveVelocityAccel += (dirMult * 2.5f) * Time.deltaTime;
			playerSpriteTransform.localScale = new Vector3(dirMult,1f,1f);
        	}
		else
		{
			MoveVelocityAccel *= 0.9f;
		}
		if (Mathf.Abs(MoveVelocityAccel) >= MaxHorizontalVelocity)
		{
			float clampMult = 1;
			if (MoveVelocityAccel < 0)
			{
				clampMult = -1;
			}
			MoveVelocityAccel = MaxHorizontalVelocity * clampMult;
		}
	        GetComponent<Rigidbody2D>().velocity = new Vector2((MoveVelocityAccel/GetComponent<Rigidbody2D>().mass),GetComponent<Rigidbody2D>().velocity.y);
	}

	void OnCollisionEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			PlayerDefeated();
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Walkable")
		{
			isJumping = false;
		}
		if (collision.gameObject.tag == "Enemy")
		{
			PlayerDefeated();
		}
	}

	void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Walkable")
		{
			isJumping = false;
		}
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Walkable")
		{
			isJumping = true;
		}
	}

	public void PlayerDefeated()
	{
		// ADD CODE HERE
		Debug.Log("Player is defeated.");
	}
}
