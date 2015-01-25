﻿using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
	GameManagerScript gm;
	//Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "Player")
		{
			if(gm.bossDead)
			{
				gm.changeLevel(0);
			}
		}
	}
}
