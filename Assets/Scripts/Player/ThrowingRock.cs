using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingRock : MonoBehaviour {

    //Force that this weapon is thrown with
    public float throwForce = 10f;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        //Give the rock a kick to get going
        rb.AddForce(transform.forward * throwForce);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
