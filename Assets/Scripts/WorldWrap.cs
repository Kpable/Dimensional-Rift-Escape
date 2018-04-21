using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldWrap : MonoBehaviour {

    public Rect worldBounds = new Rect(-40, -40, 80, 80);
	// Use this for initialization
	void Start () {
		
	}

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(new Vector3(worldBounds.xMin, worldBounds.yMin), new Vector3(worldBounds.xMin, worldBounds.yMax));
        Gizmos.DrawLine(new Vector3(worldBounds.xMin, worldBounds.yMin), new Vector3(worldBounds.xMax, worldBounds.yMin));
        Gizmos.DrawLine(new Vector3(worldBounds.xMax, worldBounds.yMin), new Vector3(worldBounds.xMax, worldBounds.yMax));
        Gizmos.DrawLine(new Vector3(worldBounds.xMin, worldBounds.yMax), new Vector3(worldBounds.xMax, worldBounds.yMax));

    }

    // Update is called once per frame
    void Update () {
        if (transform.position.x > worldBounds.xMax)
            transform.position = new Vector3(worldBounds.xMin, transform.position.y);

        if (transform.position.x < worldBounds.xMin)
            transform.position = new Vector3(worldBounds.xMax, transform.position.y);

        if (transform.position.y > worldBounds.yMax)
            transform.position = new Vector3(transform.position.x, worldBounds.yMin);

        if (transform.position.y < worldBounds.yMin)
            transform.position = new Vector3(transform.position.x, worldBounds.yMax);

    }
}
