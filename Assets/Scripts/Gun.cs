using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public Transform spawnPosition;
    public GameObject bulletPrefab;
    public float bulletSpeed = 3f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Fire()
    {
        GameObject go = Instantiate(bulletPrefab, spawnPosition.position, transform.rotation);
        Rigidbody2D bulletBody = go.GetComponent<Rigidbody2D>();
        bulletBody.velocity = transform.up * bulletSpeed;
    }
}
