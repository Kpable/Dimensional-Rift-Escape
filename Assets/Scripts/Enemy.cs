using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kpable.Mechanics;

public class Enemy : MonoBehaviour {

    public float speed = 10f;

    GameObject target;
    Health health;
    bool moveTowardsTarget;
    bool targetInRange;
    Rigidbody2D body;

    float lastShot;
    public float delayBetweenShots = .3f;
    public Gun[] guns;

    GunType currentGun = GunType.single;

    // Use this for initialization
    void Start () {
        health = GetComponent<Health>();
        health.OnValueChanged += TookDamage;
        health.OnHealthDroppedToZero += Die;
        body = GetComponent<Rigidbody2D>();
        // find player
        target = GameObject.FindGameObjectWithTag("Player");

        // get within range
        if (target)
            moveTowardsTarget = true;

        // start shooting
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (moveTowardsTarget)
        {
            //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.fixedDeltaTime * speed);
            Vector2 force = target.transform.position - transform.position;
            body.AddForce(force.normalized * speed * Time.fixedDeltaTime);
        }
        else body.velocity = Vector2.zero;

        if (targetInRange)
        {
            Fire();
        }


        // from internet
        Vector3 diff = target.transform.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        // end from internet

        //transform.localEulerAngles = new Vector3( 0, 0, Vector2.Angle(transform.up, target.transform.position));
    }

    void TookDamage()
    {
        Debug.Log(name + " took damange");
    }

    void Die()
    {
        Debug.Log(name + " died");
        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            moveTowardsTarget = false;
            targetInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            moveTowardsTarget = true;
            targetInRange = false;
        }
    }

    void Fire()
    {
        Debug.Log(name + " firing on player");

        if (Time.time - lastShot < delayBetweenShots) return;

        switch (currentGun)
        {
            case GunType.single:
                guns[0].Fire();
                break;
            case GunType.spread:
                guns[0].Fire();
                guns[1].Fire();
                guns[2].Fire();

                break;
            case GunType.cannon:
                guns[3].Beam();
                break;
            case GunType.shield:
                break;
            case GunType.max:
                break;
            default:
                break;
        }
        lastShot = Time.time;
    }
}
