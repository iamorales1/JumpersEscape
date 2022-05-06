using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public GameObject launchPoint;

    //This is the one thing we will need to drag from the Hierarchy
    public GameObject prefabProjectile;

    public float velocityMult = 4f;

    //set these dynamically (code)
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;

    private void Awake()
    {
        Transform launchPointTransform = transform.Find("launchPoint");
        launchPoint = launchPointTransform.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTransform.position;
    }

    private void Update()
    {
        //if slingshot is not in aimingmode dont run this code
        if (!aimingMode) return;

        //get current mouse pos in 2D screen space
        Vector3 mousePos2D = Input.mousePosition;

        //convert that mouse pos to 3D world space (game space)
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //find the delta from the launch pos to the mouse pos in 3D
        Vector3 mouseDelta = mousePos3D - launchPos;

        //limit mouse delta to the radius of slingshot sphere collider
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if(mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        //move projectile to this new position
        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;

        //fire projectile
        if (Input.GetMouseButtonUp(0))
        {
            //Mouse was released
            aimingMode = false;
            projectile.GetComponent<Rigidbody>().isKinematic = false; //allows for gravity
            projectile.GetComponent<Rigidbody>().velocity = -mouseDelta * velocityMult;
            FollowCam.Instance.poi = projectile;
            projectile = null;
        }

    }

    private void OnMouseDown()
    {
        //Player has pressed the mouse button while over slingshot
        aimingMode = true;

        //instantiate a projectile
        projectile = Instantiate(prefabProjectile);

        //set projectile to launchpoint
        projectile.transform.position = launchPos;

        //set projectile .isKinematic for now
        projectile.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void OnMouseEnter()
    {
        //print("Slingshot.OnMouseEnter");
        launchPoint.SetActive(true);
    }

    private void OnMouseExit()
    {
        //print("Slingshot.OnMouseExit");
        launchPoint.SetActive(false);
    }
}
