using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private NavMeshAgent Enemy;
    public GameObject Jumper;
    public float EnemyDistanceChase = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Jumper.transform.position);

        //Run towards player
        if(distance < EnemyDistanceChase)
        {
            Vector3 dirToJumper = transform.position - Jumper.transform.position;
            Vector3 newPos = transform.position - dirToJumper;
            Enemy.SetDestination(newPos);
        }
    }
}
