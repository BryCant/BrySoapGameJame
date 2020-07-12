using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{

    public GameObject crystal;

    public float spawnTimeInc = 10f;
    private float spawnTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= spawnTime)
        {
            spawnTime = Time.time + spawnTimeInc;
            SpawnCollectibles();
        }

    }

    void SpawnCollectibles()
    {
        Vector3 randPos = transform.position + new Vector3(Random.Range(1, 3), Random.Range(1, 10), 0);
        Instantiate(crystal, randPos, transform.rotation);
    }
}
