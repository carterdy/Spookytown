using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMeleeWeapon : MeleeWeapon {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        //Hit the player
        if (other.CompareTag("Player"))
            other.gameObject.SendMessage("takeMeleeDamage", damage, SendMessageOptions.RequireReceiver);
    }
}
