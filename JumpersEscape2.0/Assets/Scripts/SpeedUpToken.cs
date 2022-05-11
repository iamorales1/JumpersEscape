using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Enrique Chavez            4/12/22
//Speed token script makes player speed up by 1 for each pick up that is touched.
public class SpeedUpToken : MonoBehaviour
{
    public GameObject SpeedingToken;
    // public JumperMove JumpMovescript; //lets me call JumperMove script variables  
    public CharControllerTest CharControllerTestScript;


    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnTriggerEnter(Collider other)
    {
        if (SpeedingToken.gameObject.tag == "Andale") //Andale means Go
        {
            
            Destroy(SpeedingToken.gameObject);
            Debug.Log("Speedup token picked up Vroom Vroom!!");
            CharControllerTestScript.speed += 1f;
            Debug.Log("Speed:" + CharControllerTestScript.speed);

        }
        
      
    }
}
