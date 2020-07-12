using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PewShooter : MonoBehaviour
{
    public Transform pewPoint;
    public GameObject pewPrefab;


    // Update is called once per frame
    void Update()
    {
        // TODO Make Fire random as well
        if (Input.GetButtonDown("Fire1"))
        {
            // Shoot; Create laser beam
            Instantiate(pewPrefab, pewPoint.position, pewPoint.rotation);
        }
    }
}
