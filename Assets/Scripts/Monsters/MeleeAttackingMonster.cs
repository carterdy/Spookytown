using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Parent script for monsters that attack in melee */

public class MeleeAttackingMonster : GenericMonster {

    //Melee attack range of this monster
    public float attackRange;

    /*****************************
        Monobehaviour Functions
    *****************************/

    protected override void Awake()
    {
        base.Awake();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void FixedUpdate()
    {
        //Check to see if player is in attack range
        if (playerInAttackRange())
        {
            meleeAttack();
        }
        base.FixedUpdate();
    }

    /*****************************
           Custom Functions
    *****************************/

    /* Perform a melee attack */
    void meleeAttack()
    {
        //TODO: Play attacking animation and swing monster's weapon
        animator.SetTrigger("Attack");
    }

    /* Return True if the player is within this monster's attack range */
    bool playerInAttackRange()
    {
        //Using squared values since the Unity manual says it is more effienct to not calculate the full magnitude
        Transform playerLoc = player.transform;
        return attackRange * attackRange > ((playerLoc.position - transform.position).sqrMagnitude);
    }
}
