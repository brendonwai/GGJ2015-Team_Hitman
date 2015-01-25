using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 3);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D coll)
	{
        if(this.gameObject.tag == "Enemy")
        {
            if ((coll.tag == "Player") || (coll.tag == "Enemy"))
            {
                if(coll != this) //This allows enemies to shoot each other
                {
                    coll.GetComponent<Player>().TakeDamage();
                    Debug.Log("Player Hit");
                }
                
            }
        }
        else if(this.gameObject.tag == "Player")
        {
            if (coll.tag == "Enemy" || coll.tag == "Boss")
            {
                coll.GetComponent<EnemyAI>().TakeDamage();
                Debug.Log("Enemy Hit");
            }
        }
		
	}
}
