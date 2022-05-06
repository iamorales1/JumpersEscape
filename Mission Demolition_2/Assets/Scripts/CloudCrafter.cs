using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCrafter : MonoBehaviour
{

    //# of clouds to make
    public int numClouds = 40;

    //array to hold the clouds prefabs were going to make
    public GameObject[] cloudPrefabs;

    //min pos of each cloud
    public Vector3 CloudPosMin;

    //max pos of each cloud
    public Vector3 CloudPosMax;

    //min scale for each cloud
    public float cloudScaleMin = 1f;

    //max scale for each cloud
    public float cloudScaleMax = 5f;

    //speed adjuster
    public float cloudSpeedMult = 0.5f;

    //array to hold the instance of each prefab be instiatiate
    public GameObject[] cloudInstances;

    // Start is called before the first frame update
    void Awake()
    {
        //make the array large enough to hold all the cloud instances
        cloudInstances = new GameObject[numClouds];

        //find the cloudAnchor parent obj
        GameObject anchor = GameObject.Find("cloudAnchor");

        //iterate through and make each cloud
        GameObject cloud;
        for (int i = 0; i < numClouds; i++)
        {
            //pick and int between 0 and numClouds.length-1
            //NOTE - Random.Range will not ever return the highest number
            int prefabNUM = Random.Range(0, cloudPrefabs.Length);

            //make an instance of a cloud
            cloud = Instantiate(cloudPrefabs[prefabNUM]) as GameObject;

            //position the cloud
            Vector3 cPos = Vector3.zero;
            cPos.x = Random.Range(CloudPosMin.x, CloudPosMax.x);
            cPos.y = Random.Range(CloudPosMin.y, CloudPosMax.y);

            //scale the cloud
            float scaleU = Random.value;
            float scaleValue = Mathf.Lerp(cloudScaleMin, cloudScaleMax, scaleU);

            //here's the vection in action
            //smaller clouds (with scaleU values) should be near the ground (simulating depth)
            cPos.y = Mathf.Lerp(CloudPosMin.y, cPos.y, scaleU);
            //smaller clouds get moved further away
            cPos.z = 100 - 90 * scaleU;

            //apply transforms to cloud
            cloud.transform.position = cPos;
            cloud.transform.localScale = Vector3.one * scaleValue;

            //make cloud a child of anchor
            cloud.transform.parent = anchor.transform;

            //add cloud to our instances array
            cloudInstances[i] = cloud;

        }
    }

    // Update is called once per frame
    void Update()
    {
        //iterate over each cloud that was created
        foreach (GameObject cloud in cloudInstances)
        {
            //get cloud scale and postion
            float scaleVal = cloud.transform.localScale.x;
            Vector3 cPos = cloud.transform.localPosition;

            //move the cloud leftwards
            cPos.x -= scaleVal * Time.deltaTime * cloudSpeedMult;

            //if cloud moved too far to the left, reset it to the far right
            if(cPos.x <= CloudPosMin.x)
            {
                cPos.x = CloudPosMax.x;
            }

            //apply thses changes to the cloud
            cloud.transform.localPosition = cPos;
        }
    }
}
