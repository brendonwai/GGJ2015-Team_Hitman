using UnityEngine;
using System.Collections;

//The GameManager's function is to keep track of when a random event occurs. 
public class GameManagerScript : MonoBehaviour {

	GameObject bossEnemy;
	Player player;
	public int karma;
	public int numOfEnemies;
	public bool bossDead = false;
	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}
	// Use this for initialization
	void Start () 
	{
		karma = 100;

		bossEnemy = GameObject.FindGameObjectWithTag("Boss");	
		if(bossEnemy == null)
		{
			Debug.Log("Boss not found");
		}
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		numOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void triggerRandomEvent()
	{
		//Check karma level before triggering event
        int triggerChance = 100 - karma;

        //The higher the triggerChance, the more likely a random event will occur.
        if((int)Random.Range(0, 100) < triggerChance)
        {
            RandomEvent.executeRandomEvent();
        }
		
	}

	public void changeLevel(int input)
	{
		switch(input)
		{
		case 0:
			Application.LoadLevel (input);
			break;
		case 1:
			Application.LoadLevel (input);
			break;
		case 2:
			Application.LoadLevel (input);
			break;
		case 3:
			Application.LoadLevel (input);
			break;
		}
	}

	void resetPlayer()
	{
		player.canPunch = true;
		player.canShoot = true;
		player.canThrow = true;
	}

	//Decrease numOfEnemies and decrease karma
	void decreaseEnemyCount()
	{
		numOfEnemies--;
		karma -= 3;
	}


}
