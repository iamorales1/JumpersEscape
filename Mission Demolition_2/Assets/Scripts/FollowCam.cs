using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    //a follow cam singleton - lazy version
    static public FollowCam Instance;

    //point of interest - what the camera is going to follow
    public GameObject poi;

    //initial Z pos of the camera - allow us to go back to the slingshot
    public float camZ;

    public float easing = 0.05f;

    //limit for x and y values
    public Vector2 minXY;

    private void Awake()
    {
        //initialize our singleton
        Instance = this;
        camZ = this.transform.position.z;
    }

    private void FixedUpdate()
    {
        //dont do anything if poi is null
        //if (poi == null) return;

        //get position of poi
        Vector3 destination;

        //if there is no poi, return to 0,0,0
        if(poi == null)
        {
            destination = Vector3.zero;
        }
        else
        {
            destination = poi.transform.position;

            //if poi is aprojectile, check to see if its at rest
            if(poi.tag == "projectile")
            {
                //if its sleeping (sleeping means not moving to physics system)
                if (poi.GetComponent<Rigidbody>().IsSleeping())
                {
                    //return to start view
                    poi = null;
                    //in the next update
                    return;
                }
            }
        }
        //limit cam x and y
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        destination = Vector3.Lerp(transform.position, destination, easing);

        //retain the destination.z of camZ
        destination.z = camZ;

        //set the camera to the destination
        transform.position = destination;

        //set the orthgraphic size of cam to keep the ground in view
        this.GetComponent<Camera>().orthographicSize = destination.y + 10;
    }
}
