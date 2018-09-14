using System.Collections;
using System.Collections.Generic;
using LOS.Event;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float jumpForce;
	
	[SerializeField] private float speed;

	[SerializeField] private float dashDurationInSecond;

	[SerializeField] private float dashSpeed;

	[SerializeField] private float dashCooldownInSeconds;
	private bool jumping=false;
	private Rigidbody2D rigidbody;
	private SpriteRenderer renderer;
	private PlayerInputs controller;
	public bool isDashing=false;
	public bool canDash = true;
	public bool isJumping = false;
	public bool canJump = true;
	private int currentDir=1;
	// Use this for initialization
	private void Awake()
	{
		rigidbody = GetComponentInParent<Rigidbody2D>();
		renderer = GetComponent<SpriteRenderer>();
	}
	

	public void Move(int dir)
	{
		currentDir = dir;
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

	public virtual void Dash()
	{
		transform.root.position=transform.root.position+Vector3.up*0.01f;
		StartCoroutine(DashRoutine());
	}

	private IEnumerator DashRoutine()
	{   
		float time=0; //create float to store the time this coroutine is operating

		isDashing = true;
		canDash = false;
		while(dashDurationInSecond > time) //we call this loop every frame while our custom boostDuration is a higher value than the "time" variable in this coroutine
		{
			time += Time.deltaTime; //Increase our "time" variable by the amount of time that it has been since the last update
			rigidbody.velocity = Vector2.right * currentDir * dashSpeed; //set our rigidbody velocity to a custom velocity every frame, so that we get a steady boost direction like in Megaman
			yield return 0; //go to next frame
		}
		rigidbody.velocity = Vector2.zero;
		isDashing = false;
		
		yield return new WaitForSeconds(dashCooldownInSeconds); //Cooldown time for being able to boost again, if you'd like.
		canDash = true;
		//set player can dash to true;
	}

	private void OnCollisionEnter(Collision other)
	{
		if (isJumping)
		{
			 
		}
	}
}
