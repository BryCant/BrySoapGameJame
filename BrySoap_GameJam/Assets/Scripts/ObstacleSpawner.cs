using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleSpawner : MonoBehaviour
{
    // public Transform spawnPoint;
    public GameObject obstacle1;
    public GameObject obstacle2;

    public float spawnTimeInc = 10f;
    private float spawnTime = 0f;
    public int obLength = 2;


    void Update()
    {
        if (Time.time >= spawnTime)
        {
            spawnTime = Time.time + spawnTimeInc;
            if (spawnTimeInc >= 1.5f)
            {
            spawnTimeInc -= .01f;
            }
            SpawnObstacles();
        }
    }

    void SpawnObstacles()
    {
        int chosenObstacle = Random.Range(0, obLength);
        Vector3 randPos = transform.position + new Vector3(0, Random.Range(1, 10), 0);
        if (chosenObstacle == 0)
        {
            Instantiate(obstacle1, randPos, transform.rotation);
        }
        else if (chosenObstacle == 1)
        {
            Instantiate(obstacle2,  randPos, transform.rotation);
        }
    }
}
