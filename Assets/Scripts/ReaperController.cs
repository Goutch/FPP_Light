using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperController : PlayerController{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Lights")
		{
			
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Darkness")
		{
			
		}
	}

	public override void Dash()
	{
		
	}
}
