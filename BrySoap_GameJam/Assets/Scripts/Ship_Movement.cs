using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Movement : MonoBehaviour
{
    private Vector3 V3_Zero = Vector3.zero;

    public Rigidbody2D ship_rb;

    public Animator b1Anim;
    public Animator b2Anim;
    public Animator b3Anim;
    public Animator b4Anim;

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
            b1Anim.SetBool("B1Boosted", true);
        }
        else if (horizontalAxis > 0)
        {
            b2Anim.SetBool("B2Boosted", true);
        }

        if (verticalAxis < 0)
        {
            b3Anim.SetBool("B3Boosted", true);
        }
        else if (verticalAxis > 0)
        {
            b4Anim.SetBool("B4Boosted", true);
        }
    }

    void ResetBoosters()
    {
        b1Anim.SetBool("B1Boosted", false);
        b1Anim.SetBool("B1Boosted", false);
        b1Anim.SetBool("B1Boosted", false);
        b1Anim.SetBool("B1Boosted", false);

    }

    void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector2(horizontalAxis * Time.fixedDeltaTime * 10f, verticalAxis * Time.fixedDeltaTime * 10f);
        ship_rb.velocity = Vector3.SmoothDamp(ship_rb.velocity, targetVelocity, ref V3_Zero, floatiness);
        ResetBoosters();
    }

}
