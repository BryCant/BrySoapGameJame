using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBehaviour : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public float speed = 2;

    private void Start()
    {
        rb.velocity = transform.right * speed * -1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(GoByeBye());
        }
    }

    IEnumerator GoByeBye()
    {
        anim.SetBool("IsCollected", true);
        yield return new WaitForSeconds(.3f);
        Destroy(gameObject);
    }

}
