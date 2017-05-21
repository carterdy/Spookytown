using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericMonster : ActorControllerScript {

    //Reference to player
    public GameObject player;
    //Monster's speed
    public float moveSpeed;
    //Monster's aggro range as a vector distance
    public float aggroRange;
    //Force the monster staggers with
    public float staggerForce;

    //The player's last known location
    protected Transform playerLoc;
    //This monster's rigid body
    protected Rigidbody2D rb;
    //This monster's Animator
    protected Animator animator;

    /*****************************
        Monobehaviour Functions
    *****************************/

    // Use this for initialization
    protected virtual void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void FixedUpdate()
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

    /* Actions to perform when this monster collides with a trigger */
    void OnTriggerEnter (Collider other)
    {
    }

    /*****************************
           Custom Functions
    *****************************/

    /* Move this actor in the given direction indefinately */
    protected void Move (Vector2 direction)
    {
        rb.velocity = new Vector2(direction.x * moveSpeed, direction.y);
        //Now make sure we're facing the right way
        Debug.Log(rb.velocity);
        Debug.Log(facingRight);
        if (direction.x <= 0)
            faceLeftMonster();
        else if (direction.x > 0)
            faceRightMonster();
    }

    /* Stop moving this actor */
    protected void stopMovement ()
    {
        rb.velocity = new Vector2(0, 0);
    }

    /* Move this actor towards the target transform.
       Movement is only in the x axis*/
    void moveToTarget (Transform target)
    {
        Vector2 heading = target.position - transform.position;
        Vector2 direction = heading / heading.magnitude;
        Move(new Vector2(direction.x, 0));
    }

    /* Return True if the player is within the aggro range of this monster */
    bool playerInAggroRange()
    {
        //Using squared values since the Unity manual says it is more effienct to not calculate the full magnitude
        return aggroRange * aggroRange > ((playerLoc.position - transform.position).sqrMagnitude);
    }
}
