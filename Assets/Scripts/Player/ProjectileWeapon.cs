using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileWeapon : MonoBehaviour {

    //Force that this weapon is thrown with
    public float throwForce = 10f;
    public float upForce = 0f;

    //RigidBody2d of the projectile
    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
