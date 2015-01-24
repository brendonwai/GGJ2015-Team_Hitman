using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	[SerializeField]
	private float timeToLive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timeToLive -= Time.deltaTime;

		if (timeToLive > 0)
			Die();
	}

	void OnTriggerEnter(Collider coll)
	{
		//Destroy (this.gameObject);
		coll.gameObject.SendMessage ("hurt");
		
	}

	void Die()
	{
		Destroy(this.gameObject);
	}
}
