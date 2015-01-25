using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	public Rigidbody2D Bullet;
	private Animator anim;
	private GameManagerScript gm;
    private float timer;

	private bool isAlive;

	void Start () {
		anim=GetComponent<Animator> ();
		isAlive = true;
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(isAlive)
		{
			Vector3 targetDir = player.transform.position - transform.position;
			float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
			if(Vector3.Distance(transform.position, player.transform.position) < 5.0f)
				transform.position += targetDir.normalized * .035f;
			else
			{
                timer += Time.deltaTime;
                if(timer >= 1.25)
                {
                    Rigidbody2D clone;
                    Vector3 pe = transform.FindChild("ProjectileEmitter").position;
                    clone = Instantiate(Bullet, pe, transform.rotation) as Rigidbody2D;
                    clone.velocity = transform.TransformDirection(Vector3.up * 20);
                    timer = 0;
                }
				
			}
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
			anim.SetBool("walk", false);
			SpriteRenderer sr = GetComponent<SpriteRenderer>();
			sr.color = Color.red;
			GetComponent<BoxCollider2D>().enabled = false;
			GameObject splatter = transform.FindChild("BloodSplat").gameObject;
			splatter.SetActive(true);
			Debug.Log("Enemy Died");
		}

		if(this.gameObject.tag == "Boss")
		{
			gm.SendMessage("triggerRandomEvent");
			gm.bossDead = true;
		}
			

	}
}
