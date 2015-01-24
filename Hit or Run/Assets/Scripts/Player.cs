using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public GameObject Bullet;
	public Vector3 playerPosition;
	// Use this for initialization
	void Start () 
	{
	    
	}
	
	// Update is called once per frame
	void Update () 
	{
		CharacterController controller = GetComponent<CharacterController>();
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
		//Character Controls
		if (Input.GetKey (KeyCode.A))
			controller.Move (Vector3.left * Time.deltaTime * 5);
		if (Input.GetKey (KeyCode.D))
			controller.Move (Vector3.right * Time.deltaTime * 5);
		if (Input.GetKey (KeyCode.W))
			controller.Move (Vector3.up * Time.deltaTime * 5);
		if (Input.GetKey (KeyCode.S))
			controller.Move (Vector3.down * Time.deltaTime * 5);
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
