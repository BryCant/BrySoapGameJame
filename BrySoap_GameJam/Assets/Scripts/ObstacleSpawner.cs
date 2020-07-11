using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject[] obstacles;

    public float spawnTimeInc = 10f;
    private float spawnTime = 0f;
    

    void Update()
    {
        if (Time.time >= spawnTime)
        {
            spawnTime = Time.time + spawnTimeInc;

            int numOfObstacles = Random.Range(1,5);

            for (int obstacle = 0; obstacle < numOfObstacles; obstacle++)
            {
                int randomObstacleIndex = Random.Range(0, obstacles.Length);
                Instantiate(obstacles[randomObstacleIndex], transform.position, transform.rotation);
            }
        }
    }
}
