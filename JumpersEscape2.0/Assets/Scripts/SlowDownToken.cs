using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownToken : MonoBehaviour
{
    [SerializeField]
    private GameObject SlowParticleVariant;

    public GameObject SpeedDownToken;
    //public EnemyMove EnemyMoveScript;
    public CharControllerTest CharControllerTestScript;

    public void OnTriggerEnter(Collider other)
    {
        if (SpeedDownToken.gameObject.tag == "Slow")
        {
            Destroy(SpeedDownToken.gameObject);
            Debug.Log("SpeedDown token picked up !!Moorv Moorv");
            CharControllerTestScript._speed -= 2f;
            Debug.Log("Speed:" + CharControllerTestScript._speed);
            Instantiate(SlowParticleVariant, gameObject.transform.position, Quaternion.identity);
        }
    }

}
