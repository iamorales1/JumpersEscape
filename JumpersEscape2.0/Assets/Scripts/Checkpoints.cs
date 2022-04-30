using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public CharControllerTest jumpPoint;

    public Renderer Rend;

    public Material checkOff;
    public Material checkOn;

    public Checkpoints[] checkpoint;

     void Start()
    {
        jumpPoint = FindObjectOfType<CharControllerTest>();
    }

     void Update()
    {
        
    }

    public void checkPointOn()
    {


        Checkpoints[] checkpoint = FindObjectsOfType<Checkpoints>();
        foreach (Checkpoints cp in checkpoint)
        {
            cp.checkPointOff();
        }


    Rend.material = checkOn;
    }


    public void checkPointOff()
    {
        Rend.material = checkOff;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Jumper"))
        {
            jumpPoint.setSpawnPoint(transform.position);
            checkPointOn();
        }
    }
}
