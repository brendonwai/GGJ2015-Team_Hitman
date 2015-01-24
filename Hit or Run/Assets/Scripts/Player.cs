using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public GameObject Bullet;
	public Vector3 playerPosition;
	public float speed=10;
	private Animator anim;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}

	//Use FixedUpdate for frame-independent physics activities
	void FixedUpdate(){
		//alternative character control
		//make your life easier with this instead of setting each of wasd keys
		rigidbody2D.velocity = new Vector2 (Input.GetAxis ("Horizontal")*speed, Input.GetAxis ("Vertical")*speed);

		/*
		playerPosition = transform.position;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit = new RaycastHit ();

		if (Physics.Raycast (ray, out hit, 100)) 
		{
			Vector3 hitPoint = hit.point;
			Vector3 targetDir = hitPoint - transform.position;
			
			float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
		*/
	}

	// Update is called once per frame
	void Update () 
	{

		if(rigidbody2D.velocity!=Vector2.zero)
			anim.SetBool("walk",true);
		
		else
			anim.SetBool("walk",false);


		//Character Controls
		/*
		if (Input.GetKey (KeyCode.A))
			controller.Move (Vector3.left * Time.deltaTime * 5);
		if (Input.GetKey (KeyCode.D))
			controller.Move (Vector3.right * Time.deltaTime * 5);
		if (Input.GetKey (KeyCode.W))
			controller.Move (Vector3.up * Time.deltaTime * 5);
		if (Input.GetKey (KeyCode.S))
			controller.Move (Vector3.down * Time.deltaTime * 5);
			*/
		//transform.RotateAround (transform.position, Vector3.forward, .1f);

		//Create bullet with Left Click
		if (Input.GetKeyDown (KeyCode.Mouse0)) 
		{
			GameObject clone;
			clone = (GameObject)Instantiate(Bullet, new Vector3(transform.position.x + 5f , transform.position.y, transform.position.z), transform.rotation);
			clone.rigidbody.velocity = transform.TransformDirection(Vector3.right * 10);
		}
			

	}

	void hurt()
	{
		//Destoy (this.gameObject);
	}
}
