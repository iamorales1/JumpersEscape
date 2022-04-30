using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownToken : MonoBehaviour
{
    public GameObject SpeedDown;
    public EnemyMove EnemyMoveScript;

    public void OnTriggerEnter(Collider other)
    {
        if (SpeedDown.gameObject.tag == "Slow")
        { 
            Destroy(SpeedDown.gameObject);

            EnemyMoveScript.EnemyDistanceChase -= 1;
            Debug.Log("EnemySpeed: " + EnemyMoveScript.EnemyDistanceChase);
        }
    }

}
