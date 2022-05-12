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

    // Start is called before the first frame update
    void Start()
    {
        Enemy = GetComponent<NavMeshAgent>();
        StartCoroutine(CountdownToStart());
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
            Debug.Log("TouchedJumper");
            EnemyReset();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
