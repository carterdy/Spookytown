using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleZombie : MonoBehaviour {

    //Reference to player
    public GameObject player;
    //Zombie's speed
    public float moveSpeed;
    //Zombie's aggro range as a vector distance
    public float aggroRange;

    //The player's last known location
    private Transform playerLoc;
    //This zombie's rigid body
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate ()
    {
        //Want to get the player's location so we can use it for things
        playerLoc = player.transform;
        //Check to see if the player is in aggro range and if so, act on it
        if (playerInAggroRange())
        {
            //Now move towards the player
            moveToTarget(playerLoc);
        }
    }

    /* Move this actor towards the target transform.
       Movement is only in the x axis*/
    void moveToTarget(Transform target)
    {
        Vector2 heading = target.position - transform.position;
        Vector2 direction = heading / heading.magnitude;
        rb.AddForce(new Vector2(direction.x, 0) * moveSpeed);
    }

    /* Return True if the player is within the aggro range of this zombie */
    bool playerInAggroRange ()
    {
        //Using squared values since the Unity manual says it is more effienct to not calculate the full magnitude
        return aggroRange*aggroRange > ((playerLoc.position - transform.position).sqrMagnitude);
    }


}
