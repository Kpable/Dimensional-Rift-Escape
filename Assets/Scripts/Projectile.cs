using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Die", 3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit something:" + collision.gameObject.name);
        CancelInvoke("Die");
        Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
