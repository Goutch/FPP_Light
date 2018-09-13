using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float jumpForce;
	
	[SerializeField] private float speed;

	private bool jumping=false;
	private Rigidbody2D rigidbody;
	private SpriteRenderer renderer;
	
	// Use this for initialization
	void Start ()
	{
		rigidbody = GetComponentInParent<Rigidbody2D>();
		renderer = GetComponent<SpriteRenderer>();
	}
	

	public void Move(int dir)
	{
		
		if (dir == -1)
		{
			renderer.flipX = true;
		}
		else
		{
			renderer.flipX = false;
		}
		transform.root.Translate(Vector2.right*dir*speed*Time.deltaTime);
	}

	public void Jump()
	{
		rigidbody.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
	}
}
