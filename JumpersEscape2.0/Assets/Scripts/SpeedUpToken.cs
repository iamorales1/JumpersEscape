using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Enrique Chavez            4/12/22
//Speed token script makes player speed up by 1 for each pick up that is touched.
public class SpeedUpToken : MonoBehaviour
{
    public GameObject SpeedUp;
    public JumperMove JumpMovescript; //lets me call JumperMove script variables  
    
    // Update is called once per frame
    void Update()
    { 
        //check for speed change  
        Debug.Log("Speed: "+JumpMovescript.speed);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (SpeedUp.gameObject.tag == "Andale") //Andale means Go
        {
            //gets rid of the token 
            Destroy(SpeedUp.gameObject);
            Debug.Log("Speedup token picked up");
            //need to make the player speed up now
            JumpMovescript.speed++;
        }
    }
}
