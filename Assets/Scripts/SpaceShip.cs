using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour {


    public float maxSpeed = 5f;
    public float rotationSpeed = 180f;
    public float shipBoundaryRadius = 0.5f;
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

        //pos = RestrictToCameraBounds(pos);
        transform.position = pos;
    }

    Vector3 RestrictToCameraBounds(Vector3 pos)
    {
        pos.y = Mathf.Clamp(pos.y, -Camera.main.orthographicSize + shipBoundaryRadius, Camera.main.orthographicSize - shipBoundaryRadius);
        float ratio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * ratio;
        pos.x = Mathf.Clamp(pos.x, -widthOrtho + shipBoundaryRadius, widthOrtho - shipBoundaryRadius);

        return pos;

    }
}
