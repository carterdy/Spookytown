using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour {

    public GenericMonster genericMonster;
    public Transform eyes;
    public State currentState;

    private bool aiActive;

    private void Awake()
    {
        genericMonster = GetComponent<GenericMonster>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!aiActive)
            return;
        currentState.updateState(this);
	}

    private void OnDrawGizmos()
    {
        if (currentState != null && eyes != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(eyes.position, genericMonster.aggroRange);
        }
    }
}
