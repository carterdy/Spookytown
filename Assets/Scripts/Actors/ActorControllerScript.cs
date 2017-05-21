using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActorControllerScript : MonoBehaviour {

    //Actor's hit points
    public int HP;

    //True if the actor should be facing right
    protected bool facingRight;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*****************************
           Custom Functions
    *****************************/

    /* Called to flip the character around the y axis */
    protected void Flip()
    {
        facingRight = !facingRight;
        if (facingRight)
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        else
            transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
    }

    /* These functions are kinda dumb but because I can't draw all sprites facing the same direction nicely and incase I forget to flip them */

    /* Face the actor to the right
       Use for sprites originally facing right */
    protected void faceRightPlayer ()
    {
        facingRight = true;
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }

    /* Face the actor to the left
       Use for sprites originally facing right */
    protected void faceLeftPlayer ()
    {
        facingRight = false;
        transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
    }

    /* Face the actor to the right
       Use for sprites originally facing left */
    protected void faceRightMonster ()
    {
        facingRight = true;
        transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
    }

    /* Face the actor to the left
       Use for sprites originally facing left */
    protected void faceLeftMonster ()
    {
        facingRight = false;
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }

    /* Kill this monster */
    void die()
    {
        //Play a death animation (so this will have to become a coroutine eventually I guess)
        Destroy(gameObject);
    }

    /* Deal damage to this monster equal to the damage given */
    void takeDamage(int damage)
    {
        HP -= damage;
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
