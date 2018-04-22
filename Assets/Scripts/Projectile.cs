using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kpable.Mechanics;
public class Projectile : MonoBehaviour {

    public int damage = 2;
	// Use this for initialization
	void Start () {
        Invoke("Die", 3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Hit something:" + collider.name);

        Health health = collider.gameObject.GetComponent<Health>();
        if (health != null)
            health.Damage(damage);

        CancelInvoke("Die");
        Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
