using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{

    public Rigidbody2D rb;
    public float obstacleSpeed = 5f;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 8);
        Physics2D.IgnoreLayerCollision(8, 9);
        rb.velocity = transform.right * -obstacleSpeed;

        float randScale = Random.Range(.2f, .5f);
        transform.localScale = new Vector3(randScale, randScale, randScale);

        float randRot = Random.Range(0f, 359f);
        transform.Rotate(0f, 0.0f, randRot, Space.Self);
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
