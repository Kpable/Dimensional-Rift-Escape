using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kpable.Mechanics; 

public class Meteor : MonoBehaviour {

    Health health;

	// Use this for initialization
	void Start () {
        health = GetComponent<Health>();
        health.OnHealthDroppedToZero += Die;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Die()
    {
        Debug.Log(name + " destroyed");
        Destroy(gameObject);
    }
}
