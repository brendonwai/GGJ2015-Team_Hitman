using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        //Destroy (this.gameObject);
        if (coll.tag == "Enemy" || coll.tag == "Boss")
        {
            coll.GetComponent<EnemyAI>().TakeDamage();
            Debug.Log("Enemy Hit");
        }
    }
}
