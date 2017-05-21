using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMeleeWeapon : MeleeWeapon {


    void OnTriggerEnter2D (Collider2D other)
    {
        //Hit the player
        if (other.CompareTag("Player"))
            other.gameObject.SendMessage("takeMeleeDamage", damage, SendMessageOptions.RequireReceiver);
    }
}
