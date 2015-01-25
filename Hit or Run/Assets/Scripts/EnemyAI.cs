using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	private Animator anim;
	private GameManagerScript gm;

	private bool isAlive;

	void Start () {
		anim=GetComponent<Animator> ();
		isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
        if(isAlive)
        {
            Vector3 targetDir = player.transform.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

            transform.position += targetDir.normalized * .1f;
            anim.SetBool("walk", true);
        }
		
	}

	//When this enemy dies, tell GameManager to reduce enemy count and decrease karma
	public void TakeDamage()
	{
        
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
		if (gm != null)
        {
            gm.SendMessage("decreaseEnemyCount");
            isAlive = false;
            Debug.Log("Enemy Died");
            anim.SetBool("walk", false);
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.color = Color.red;
        }
			

	}
}
