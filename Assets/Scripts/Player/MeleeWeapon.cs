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

    // Destroys weapon at end of animation
    void endAttack ()
    {
        swinging = false;
        gameObject.SetActive(false);
    }

}
