using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {

    /* Most of basis for movement from Code from https://unity3d.com/learn/tutorials/topics/2d-game-creation/2d-character-controllers 
    --since I don't know great ways to do jumping */

    //Maximum speed the character can move
    public float maxSpeed = 10f;
    //Strength of jumps
    public float jumpForce = 10f;

    //Ranged weapon currently equipped
    public GameObject equippedRangedWeapon;
    //Offset vector from with ranged weapon projectiles will be launched
    public Vector3 rangedWeaponOffset = new Vector3(0.25f, 0f, 0f);

    //Force to "glue" character to ground
    public float groundingForce = 5f;
    //Transform used to check where the ground should be
    public Transform groundCheck;
    //LayerMask for knowing what is ground
    public LayerMask whatIsGround;
    //Slippery material for in air
    public PhysicsMaterial2D slipperyMat;
    //Normal material for ground
    public PhysicsMaterial2D normalMat;
    


    //True if the character is facing right.  Used to flip image
    bool facingRight = true;

    //To tell when grounded
    bool grounded = false;
    //Radius for ground detection
    float groundRadius = 0.05f;


    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	

    void FixedUpdate()
    {
        //check if grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        if (grounded) {
            rb.sharedMaterial = normalMat;
            glueToGround();
        }
        else {
            //Want to make the character slippery in the air to prevent weird stuff like sticking their face to walls
            rb.sharedMaterial = slipperyMat;
        }

        //Move character
        float move = Input.GetAxis("Horizontal");
        Move(move);
        //Check to see if we need to flip around
        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
        //Attacking code
        if (Input.GetButtonDown("Fire1"))
            ShootProjectile(equippedRangedWeapon);

    }

	// Update is called once per frame
	void Update () {
		
        //Check for jumping in here because FixedUpdate can miss inputs
        if (grounded && Input.GetButton("Jump"))
        {
            Jump();
        }
	}

    /* Called to flip the character around the y axis */
    void Flip()
    {
        facingRight = !facingRight;
        if (facingRight)
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        else
            transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
    }

    /* Used to control movement */
    void Move(float movement_in)
    {
        rb.velocity = new Vector2 (movement_in * maxSpeed, rb.velocity.y);
    }

    /* Used to control jumps */
    void Jump ()
    {
        grounded = false;
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    /*  We need to "glue" the character to the ground to prevent them from acting weird on slopes by adding force based off their normal to the slope
        Found basis of code from https://www.youtube.com/watch?v=xMhgxUFKakQ */
    void glueToGround()
    {
            RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, whatIsGround);
            //Add force against the normal
            rb.AddForce(-ray.normal * groundingForce);
    }


    /* Fires the character's projectile weapon.
    Takes in a GameObject representing the character's current projectile weapon*/
    void ShootProjectile (GameObject projectile)
    {
        //Just have to instantiate the projectile at the right position and let the projectile's script do the rest
        Vector3 startPos = transform.TransformPoint(rangedWeaponOffset);
        GameObject active_projectile = Instantiate(projectile, startPos, transform.rotation) as GameObject;
    }

}
