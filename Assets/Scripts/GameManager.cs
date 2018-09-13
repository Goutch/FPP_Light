using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	private IPlayer _player;
	private  human;
	private  reaper;
	
	
	void Start () {
		human = GameObject.Instantiate(Player);
		reaper = new ReaperController();
		_player = human;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
