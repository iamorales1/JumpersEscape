
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleBlock : MonoBehaviour
{
    public GameObject Destructible;
   // public GameObject player; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnTriggerEnter(Collider other)
    {
        if (Destructible.gameObject.tag == "Break")
        {

            Destroy(Destructible.gameObject, 3.0f);

            //Destructible.SetActive(false);

        }

    }

}