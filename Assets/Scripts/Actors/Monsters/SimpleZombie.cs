using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleZombie : MeleeAttackingMonster {

    //Low and high range times for random shambling
    public int shamblePeriodicLowEnd;
    public int shamblePeriodicHighEnd;
    //Low and high range duration for shambling
    public float shambleDurationLowEnd;
    public float shambleDurationHighEnd;

    /*****************************
        Monobehaviour Functions
    *****************************/
    void Start()
    {
        StartCoroutine(Shamble());
    }

    /*****************************
           Custom Functions
    *****************************/

    /* Initiate a cycle the zombie's random shambling.
       Zombie will walk back and forth for a random duration determined by shambleDuration and repeat randomly determined by shamblePeriodic*/
    IEnumerator Shamble()
    {
        //Get new shamble duration
        float duration = Random.Range(shambleDurationLowEnd, shambleDurationHighEnd);
        Vector2 direction;
        if (facingRight)
            direction = new Vector2(-1, 0);
        else
            direction = Vector2.right;
        //Move for the duration
        while (duration > 0)
        {
            Move(direction);
            duration -= Time.deltaTime;
            yield return null;
        }
        //Wait a new random time to shamble again
        float waitTime = Random.Range(shamblePeriodicLowEnd, shamblePeriodicHighEnd);
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(Shamble());
    }
}
