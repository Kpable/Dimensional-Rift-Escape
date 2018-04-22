using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : MonoBehaviour {

    public float maxDistance = 20f;
    float beamlength;
    LineRenderer lr;
	// Use this for initialization
	void Start () {
        lr = GetComponent<LineRenderer>();

        //StartCoroutine("UpdateBeam");
	}
	
	// Update is called once per frame
	void Update () {
        
        //Vector3 hitpoint = Vector3.zero;
        //if (hit.collider == null) hitpoint = transform.up * maxDistance;
        //else hitpoint = hit.point;
        ////Debug.Log("hitcount:" + hit.transform.name);
        //Debug.DrawLine(transform.position, hit.point);
        //Vector3 transformedPoint = hitpoint;
        //if( hit.collider != null) transformedPoint = transform.InverseTransformPoint(hitpoint);
        //lr.SetPosition(1, transformedPoint);

        // if we got a hit raycast from there and keep going with remaining distance. 
	}

    IEnumerator UpdateBeam()
    {
        yield return null;
        RaycastHit2D[] hit;
        int points = 1;
        Vector3 lastHitPoint = transform.position;
        Vector3 dirToFire = transform.up;
        beamlength = 0;
        while (beamlength < maxDistance)
        {
            hit = Physics2D.RaycastAll(lastHitPoint, dirToFire, maxDistance - beamlength);
            for (int i = 0; i < hit.Length; i++)
            {
                if (new Vector3(hit[i].point.x, hit[i].point.y, lastHitPoint.z) == lastHitPoint && hit.Length > 1)
                    continue;

                if (hit[i].collider == null || hit.Length == 1)
                {
                    lr.SetPosition(points, dirToFire * (maxDistance - beamlength));
                    beamlength = maxDistance;
                }
                else
                {
                    beamlength += hit[i].distance;
                    lr.SetPosition(points, transform.InverseTransformPoint(hit[i].point));
                    points++;
                    lr.positionCount = points + 1;
                    lastHitPoint = hit[i].point;

                    // get reflection
                    dirToFire = Vector3.Reflect(dirToFire, hit[i].normal);

                }
                break; // only care about the first thing we hit.
            }
        }
        StartCoroutine("UpdateBeam");
    }
}
