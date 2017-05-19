using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileWeapon : MonoBehaviour {

    //Force that this weapon is thrown with
    public float throwForce = 10f;
    public float upForce = 0f;
    //Damage of this weapon
    public int damage;

    //RigidBody2d of the projectile
    private Rigidbody2D rb;

    /*****************************
        Monobehaviour Functions
    *****************************/

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D (Collision2D other)
    {
        //If we hit an enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<GenericMonster>().takeRangedDamage(damage);
        }
    }
}
