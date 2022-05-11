using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTokensScript : MonoBehaviour
{
    public GameObject SpeedUpToken;
    public GameObject SpeedDownToken;


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
        if (SpeedUpToken.gameObject.tag == "Andale") //Andale means Go
        {
            Destroy(SpeedUpToken.gameObject);
            Debug.Log("Speedup token picked up Vroom Vroom!!");
           
        }

        if (SpeedDownToken.gameObject.tag == "Slow") //Andale means Go
        {
            Destroy(SpeedDownToken.gameObject);
            Debug.Log("SpeedDown token picked up !!Moorv Moorv");

        }
    }

}
