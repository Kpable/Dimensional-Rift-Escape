using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GunType { single, spread, cannon, shield, max }
public class SpaceShip : MonoBehaviour {


    public float maxSpeed = 5f;
    public float rotationSpeed = 180f;

    float lastShot;
    public float delayBetweenShots = .3f;
    public Gun[] guns;

    GunType currentGun = GunType.single;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z += -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);

        pos += rot * velocity;

        transform.position = pos;

        if (Input.GetAxis("Jump") == 1)
        {
            Fire();
        }
    }

    public void Fire()
    {
        Debug.Log("Fire");

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
        {
            Debug.Log("Hit power up");

            // read what kiind of power up. 
            GunType powerUp = collision.GetComponent<PowerUp>().powerup;
            switch (powerUp)
            {
                case GunType.single:
                    guns[0].gameObject.SetActive(true);
                    guns[1].gameObject.SetActive(false);
                    guns[2].gameObject.SetActive(false);
                    guns[3].gameObject.SetActive(false);

                    break;
                case GunType.spread:
                    guns[0].gameObject.SetActive(true);
                    guns[1].gameObject.SetActive(true);
                    guns[2].gameObject.SetActive(true);
                    guns[3].gameObject.SetActive(false);

                    break;
                case GunType.cannon:
                    guns[0].gameObject.SetActive(false);
                    guns[1].gameObject.SetActive(false);
                    guns[2].gameObject.SetActive(false);
                    guns[3].gameObject.SetActive(true);
                    break;
                case GunType.shield:
                    guns[4].gameObject.SetActive(true);
                    break;
                case GunType.max:
                    break;
                default:
                    break;
            }

            currentGun = powerUp;
            //Destroy(collision.gameObject);
        }
    }

}
