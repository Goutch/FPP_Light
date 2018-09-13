using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float jumpForce;
	
	[SerializeField] private float speed;

	private bool jumping=false;
	private Rigidbody2D rigidbody;
	// Use this for initialization
	void Start ()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Move(int dir)
	{
		transform.Translate(Vector2.right*dir*Time.deltaTime);
	}

	public void Jump()
	{
		rigidbody.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
	}
}
