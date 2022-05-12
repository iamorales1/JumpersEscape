using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private NavMeshAgent Enemy;
    public GameObject Jumper;
    public float EnemyDistanceChase = 10f;

    private Vector3 startPos;
    public int countdownTime;

    private Transform spawnPoint1;
    private Transform enemyPos1;

    private Transform spawnPoint2;
    private Transform enemyPos2;

    private Transform spawnPoint3;
    private Transform enemyPos3;

    private Transform spawnPoint4;
    private Transform enemyPos4;

    private Transform spawnPoint5;
    private Transform enemyPos5;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = GetComponent<NavMeshAgent>();
        StartCoroutine(CountdownToStart());

        enemyPos1 = GameObject.FindGameObjectWithTag("Enemy1").transform;
        spawnPoint1 = GameObject.FindGameObjectWithTag("EnemyReset1").transform;

        enemyPos2 = GameObject.FindGameObjectWithTag("Enemy2").transform;
        spawnPoint2 = GameObject.FindGameObjectWithTag("EnemyReset2").transform;

        enemyPos3 = GameObject.FindGameObjectWithTag("Enemy3").transform;
        spawnPoint3 = GameObject.FindGameObjectWithTag("EnemyReset3").transform;

        enemyPos4 = GameObject.FindGameObjectWithTag("Enemy4").transform;
        spawnPoint4 = GameObject.FindGameObjectWithTag("EnemyReset4").transform;

        enemyPos5 = GameObject.FindGameObjectWithTag("Enemy5").transform;
        spawnPoint5 = GameObject.FindGameObjectWithTag("EnemyReset5").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (countdownTime > 0)
        {
            return;
        }

       
    
        float distance = Vector3.Distance(transform.position, Jumper.transform.position);

        //Run towards player
        if(distance < EnemyDistanceChase)
        {
            Vector3 dirToJumper = transform.position - Jumper.transform.position;
            Vector3 newPos = transform.position - dirToJumper;
            Enemy.SetDestination(newPos);
        }
    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            yield return new WaitForSeconds(1f);
            Jumper.SetActive(true);
            countdownTime--;
        }
    }

    public void EnemyReset()
    {
        transform.position = startPos;
    }

    public void OnTriggerEnter(Collider other)
    {
        //kills and respawner the player if colldied with the below
        if (other.tag == "Jumper")
        {
            enemyPos1.position = new Vector3(spawnPoint1.position.x, spawnPoint1.position.y, spawnPoint1.position.z);
            enemyPos2.position = new Vector3(spawnPoint2.position.x, spawnPoint2.position.y, spawnPoint2.position.z);
            enemyPos3.position = new Vector3(spawnPoint3.position.x, spawnPoint3.position.y, spawnPoint3.position.z);
            enemyPos4.position = new Vector3(spawnPoint4.position.x, spawnPoint4.position.y, spawnPoint4.position.z);
            enemyPos5.position = new Vector3(spawnPoint5.position.x, spawnPoint5.position.y, spawnPoint5.position.z);
        }
    }
}
