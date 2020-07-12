using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PewShooter : MonoBehaviour
{
    public Transform pewPoint;
    public GameObject pewPrefab;
    public MissleBar mb;

    public int MAX_MISSILES = 5;

    private void Start()
    {
        mb.SetMissile(MAX_MISSILES);
    }

    // Update is called once per frame
    void Update()
    {
        // TODO Make Fire random as well
        if (Input.GetButtonDown("Fire1") && mb.currentMissiles > 0)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Shoot; Create laser beam
        mb.currentMissiles--;
        mb.SetMissile(mb.currentMissiles);
        Instantiate(pewPrefab, pewPoint.position, pewPoint.rotation);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Crystal") && mb.currentMissiles < MAX_MISSILES)
        {
            mb.currentMissiles++;
            int randReward = Random.Range(mb.currentMissiles, MAX_MISSILES);
            mb.SetMissile(mb.currentMissiles);
        }
    }
}
