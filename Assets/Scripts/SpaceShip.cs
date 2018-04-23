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

    AudioSource source;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();

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
                source.PlayOneShot(GameManager.Instance.clips[2]);
                guns[0].Fire();
                break;
            case GunType.spread:
                source.PlayOneShot(GameManager.Instance.clips[2]);
                guns[0].Fire();
                guns[1].Fire();
                guns[2].Fire();

                break;
            case GunType.cannon:
                source.PlayOneShot(GameManager.Instance.clips[5]);
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
                    source.PlayOneShot(GameManager.Instance.clips[1]);

                    guns[0].gameObject.SetActive(true);
                    guns[1].gameObject.SetActive(false);
                    guns[2].gameObject.SetActive(false);
                    guns[3].gameObject.SetActive(false);

                    break;
                case GunType.spread:
                    source.PlayOneShot(GameManager.Instance.clips[1]);

                    guns[0].gameObject.SetActive(true);
                    guns[1].gameObject.SetActive(true);
                    guns[2].gameObject.SetActive(true);
                    guns[3].gameObject.SetActive(false);

                    break;
                case GunType.cannon:
                    source.PlayOneShot(GameManager.Instance.clips[1]);

                    guns[0].gameObject.SetActive(false);
                    guns[1].gameObject.SetActive(false);
                    guns[2].gameObject.SetActive(false);
                    guns[3].gameObject.SetActive(true);
                    break;
                case GunType.shield:
                    source.PlayOneShot(GameManager.Instance.clips[3]);
                    guns[4].gameObject.SetActive(true);
                    break;
                case GunType.max:
                    break;
                default:
                    break;
            }
            if(powerUp != GunType.shield)
                currentGun = powerUp;
            //Destroy(collision.gameObject);
        }
    }

}
