using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{

    public Rigidbody2D rb;
    public float obstacleSpeed = 5f;

    void Start()
    {
        rb.velocity = transform.right * -obstacleSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ObstacleDeath"))
        {
            Destroy(gameObject);
        }
        /*else if (other.gameObject.CompareTag("platform"))
        {
            Destroy(gameObject);
        }*/
    }
}
