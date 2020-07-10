using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Movement : MonoBehaviour
{
    public Transform Booster1;
    public Transform Booster2;
    public Transform Booster3;
    public Transform Booster4;

    private Vector3 V3_Zero = Vector3.zero;

    public Rigidbody2D ship_rb;
    public GameObject boostPrefab;

    float horizontalAxis = 0f;
    float verticalAxis = 0f;
    public float floatiness = 1f;
    public float boostSpeed = 30f;

    // Update is called once per frame
    void Update()
    {
        // Ship Control
        horizontalAxis = Input.GetAxisRaw("Horizontal") * boostSpeed * 10f;
        verticalAxis = Input.GetAxisRaw("Vertical") * boostSpeed * 10f;

        if (horizontalAxis < 0)
        {
            Instantiate(boostPrefab, Booster2.position, Booster2.rotation);
        }
        else if (horizontalAxis > 0)
        {
            Instantiate(boostPrefab, Booster4.position, Booster4.rotation);
        }

        if (verticalAxis < 0)
        {
            Instantiate(boostPrefab, Booster1.position, Booster1.rotation);
        }
        else if (verticalAxis > 0)
        {
            Instantiate(boostPrefab, Booster3.position, Booster3.rotation);
        }
    }

    void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector2(horizontalAxis * Time.fixedDeltaTime * 10f, verticalAxis * Time.fixedDeltaTime * 10f);
        ship_rb.velocity = Vector3.SmoothDamp(ship_rb.velocity, targetVelocity, ref V3_Zero, floatiness);

    }

}
