using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

    public void Beam()
    {
        Debug.Log("beam fire");
        GameObject go = Instantiate(bulletPrefab, spawnPosition.position, transform.rotation);
        go.transform.SetParent(transform);
        go.transform.DOScale(new Vector3(1f, 15), .5f).OnComplete(() => Destroy(go));
    }
}
