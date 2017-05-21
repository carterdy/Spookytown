using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Parent script for monsters that attack in melee */

public abstract class MeleeAttackingMonster : GenericMonster {

    //Melee attack range of this monster
    public float attackRange;
    //Cooldown timer for attacking
    public float attackCooldown;

    private bool attackOnCooldown = false;

    /*****************************
        Monobehaviour Functions
    *****************************/

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void FixedUpdate()
    {
        //Check to see if player is in attack range
        if (playerInAttackRange() && !attackOnCooldown)
        {
            StartCoroutine(meleeAttack());
        }
        base.FixedUpdate();
    }

    /*****************************
           Custom Functions
    *****************************/

    /* Perform a melee attack */
    IEnumerator meleeAttack()
    {
        //TODO: Play attacking animation and swing monster's weapon
        animator.SetTrigger("Attack");
        //Start a cooldown timer
        attackOnCooldown = true;
        yield return new WaitForSeconds(attackCooldown);
        attackOnCooldown = false;
        yield return null;
    }

    /* Return True if the player is within this monster's attack range */
    bool playerInAttackRange()
    {
        //Using squared values since the Unity manual says it is more effienct to not calculate the full magnitude
        Transform playerLoc = player.transform;
        return attackRange * attackRange > ((playerLoc.position - transform.position).sqrMagnitude);
    }
}
