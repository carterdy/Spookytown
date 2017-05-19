using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericMonster : MonoBehaviour {

    //Reference to player
    public GameObject player;
    //Monster's speed
    public float moveSpeed;
    //Monster's aggro range as a vector distance
    public float aggroRange;
    //Monster's hit points
    public int HP;
    //Force the monster staggers with
    public float staggerForce;

    //The player's last known location
    protected Transform playerLoc;
    //This monster's rigid body
    protected Rigidbody2D rb;

    /*****************************
        Monobehaviour Functions
    *****************************/

    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
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
    /* Kill this monster */
    void die ()
    {
        //Play a death animation (so this will have to become a coroutine eventually I guess)
        Destroy(gameObject);
    }

    /* Move this actor towards the target transform.
       Movement is only in the x axis*/
    void moveToTarget(Transform target)
    {
        Vector2 heading = target.position - transform.position;
        Vector2 direction = heading / heading.magnitude;
        rb.AddForce(new Vector2(direction.x, 0) * moveSpeed);
    }

    /* Return True if the player is within the aggro range of this monster */
    bool playerInAggroRange()
    {
        //Using squared values since the Unity manual says it is more effienct to not calculate the full magnitude
        return aggroRange * aggroRange > ((playerLoc.position - transform.position).sqrMagnitude);
    }

    /* Causes the monster to stagger */
    IEnumerator stagger()
    {
        //Start an animation TO BE IMPLIMENTED
        //TEMPORARY: flicker the monster.  Took my old code from Tandem
        float flickerTime = 0.1f;
        SpriteRenderer render = gameObject.GetComponent<SpriteRenderer>();
        render.color = Color.black;
        //Wait a sec
        yield return new WaitForSeconds(flickerTime);
        render.color = Color.white;

        yield return null;
    }

    /* Deal damage to this monster equal to the damage given */
    void takeDamage(int damage)
    {
        HP--;
        if (HP <= 0)
        {
            //R.I.P
            die();
        }
    }

    /* Deal damage to this monster from a melee source */
    public void takeMeleeDamage(int damage)
    {
        StartCoroutine(stagger());
        takeDamage(damage);
    }

    /* Deal damage to this monster from a ranged source */
    public void takeRangedDamage(int damage)
    {
        StartCoroutine(wince());
        takeDamage(damage);
    }

    /* Cause the monster to wince */
    IEnumerator wince()
    {
        //Start animation TO BE IMPLIMENTED
        //TEMPORARY: flicker the monster.  Took my old code from Tandem
        float flickerTime = 0.1f;
        SpriteRenderer render = gameObject.GetComponent<SpriteRenderer>();
        render.color = Color.black;
        //Wait a sec
        yield return new WaitForSeconds(flickerTime);
        render.color = Color.white;

        yield return null;
    }
}
