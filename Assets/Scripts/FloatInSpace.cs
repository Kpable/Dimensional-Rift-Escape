using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatInSpace : MonoBehaviour {

    public float speed = 3f;
    public float roationalSpeed = 3f;
    Rigidbody2D body;
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(Random.Range(-speed, speed), Random.Range(-speed, speed));
        body.angularVelocity = Random.Range(-roationalSpeed, roationalSpeed);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
