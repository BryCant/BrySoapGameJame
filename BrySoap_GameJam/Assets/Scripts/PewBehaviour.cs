using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PewBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public float pewSpeed = 2;

    public float pewDecayTime = 10f;
    private float pewDeathTime;

    void Start()
    {
        rb.velocity = transform.right * pewSpeed;
        pewDeathTime = Time.time + pewDecayTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= pewDeathTime)
        {
            Debug.Log("Decay");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
