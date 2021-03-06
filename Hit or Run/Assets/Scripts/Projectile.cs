﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public GameObject explosion;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 3);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "Environment")
		{
			//explosion = transform.FindChild("Shockwave").gameObject;
			Instantiate (explosion,transform.position,transform.rotation);
			Destroy (explosion,2);
			Destroy(this.gameObject);
			//explosion.SetActive(true);
			Debug.Log ("Wall was hit");
		}
		if (coll.tag == "Player")
		{
			coll.GetComponent<Player>().TakeDamage();
			Debug.Log("Player Hit");
		}
			
		if (coll.tag == "Enemy" || coll.tag == "Boss")
		{
			coll.GetComponent<EnemyAI>().TakeDamage();
			Debug.Log("Enemy Hit");
		}
		
		
	}
}
