using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	private Animator anim;
	void Start () {
		anim=GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetDir = player.transform.position - transform.position;
		float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);

		transform.position += targetDir.normalized *.1f;
		anim.SetBool ("walk", true);
	}
}
