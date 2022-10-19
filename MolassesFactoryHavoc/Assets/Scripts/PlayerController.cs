using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float HorizontalVelocityAccelerate = 0.2f;
	public float HorizontalVelocityDecccelerate = 0.5f;
	public float MaxHorizontalVelocity = 2f;
	public float JumpVelocity = 3.5f;

	public Transform playerSpriteTransform;
	public Sprite playerSprite;

	void Update()
	{
        	if (Input.GetButtonDown("Jump"))
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
	        	GetComponent<Rigidbody2D>().AddForce(new Vector2((HorizontalVelocityAccelerate/GetComponent<Rigidbody2D>().mass) * dirMult,0f),ForceMode2D.Force);
			playerSpriteTransform.localScale = new Vector3(dirMult,1f,1f);
        	}
		else
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x*HorizontalVelocityDecccelerate,GetComponent<Rigidbody2D>().velocity.y);
		}
		if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) >= MaxHorizontalVelocity)
		{
			float clampMult = 1;
			if (GetComponent<Rigidbody2D>().velocity.x < 0)
			{
				clampMult = -1;
			}

			GetComponent<Rigidbody2D>().velocity = new Vector2(MaxHorizontalVelocity * clampMult,GetComponent<Rigidbody2D>().velocity.y);
		}
	}
}
