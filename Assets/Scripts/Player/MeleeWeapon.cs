using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeWeapon : MonoBehaviour {

    //The player's 'hand' position from which the weapon will be held
    public Vector3 handPosition;
    //True when sword is being swung
    public bool swinging = false;
    //Damage dealt by this weapon
    public int damage;

    /*****************************
        Monobehaviour Functions
    *****************************/

    void Awake()
    {
        swinging = true;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Handle collisions from this weapon
    void OnTriggerEnter2D (Collider2D other)
    {
        //Hit an enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SendMessage("takeMeleeDamage", damage, SendMessageOptions.RequireReceiver);
        }
    }

    /*****************************
           Custom Functions
    *****************************/

    // Destroys weapon at end of animation
    void endAttack ()
    {
        swinging = false;
        gameObject.SetActive(false);
    }

}
