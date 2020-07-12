using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Movement : MonoBehaviour
{
    private Vector3 V3_Zero = Vector3.zero;

    public Rigidbody2D ship_rb;

    public Animator shipAnim;
    public Animator b1Anim;
    public Animator b2Anim;
    public Animator b3Anim;
    public Animator b4Anim;

    public FuelBar fb;

    float horizontalAxis = 0f;
    float verticalAxis = 0f;
    public float floatiness = 1f;
    public float boostSpeed = 30f;

    public int glitchVersion = 0;

    public int fuelBarDelay = 10;
    private int initFuelBarDelay;

    private void Start()
    {
        initFuelBarDelay = fuelBarDelay;
    }

// Update is called once per frame
void Update()
    {
        // Ship Control
        switch (glitchVersion)
        {
            case 0:
                // Regular
                horizontalAxis = Input.GetAxisRaw("Horizontal") * boostSpeed * 10f;  // Regular
                verticalAxis = Input.GetAxisRaw("Vertical") * boostSpeed * 10f;
                break;
            case 1:
                horizontalAxis = Input.GetAxisRaw("Vertical") * boostSpeed * 10f;    //        RIGHT
                verticalAxis = Input.GetAxisRaw("Horizontal") * boostSpeed * 10f;    //  DOWN  LEFT  UP
                break;
            case 2:
                horizontalAxis = Input.GetAxisRaw("Horizontal") * boostSpeed * -10f; //        DOWN
                verticalAxis = Input.GetAxisRaw("Vertical") * boostSpeed * -10f;     //  RIGHT  UP  LEFT
                break;
            case 3:
                horizontalAxis = Input.GetAxisRaw("Vertical") * boostSpeed * -10f;   //        RIGHT
                verticalAxis = Input.GetAxisRaw("Horizontal") * boostSpeed * -10f;   //  UP  LEFT  DOWN
                break;
            case 4:
                horizontalAxis = Input.GetAxisRaw("Vertical") * boostSpeed * -10f;   //     RIGHT
                verticalAxis = Input.GetAxisRaw("Horizontal") * boostSpeed * 10f;    //  UP LEFT DOWN
                break;
            case 5:
                horizontalAxis = Input.GetAxisRaw("Vertical") * boostSpeed * 10f;    //         LEFT
                verticalAxis = Input.GetAxisRaw("Horizontal") * boostSpeed * -10f;   //  DOWN  RIGHT  UP
                break;

        }

        if(fb.currentCrystals > 0)
        {
            if (horizontalAxis < 0)
            {
                b2Anim.SetBool("B2Boosted", true);
                UpdateFuelBare();
            }
            else if (horizontalAxis > 0)
            {
                b4Anim.SetBool("B4Boosted", true);
                UpdateFuelBare();
            }

            if (verticalAxis < 0)
            {
                b1Anim.SetBool("B1Boosted", true);
                UpdateFuelBare();
            }
            else if (verticalAxis > 0)
            {
                b3Anim.SetBool("B3Boosted", true);
                UpdateFuelBare();
            }
        }
    }

    void UpdateFuelBare()
    {
        if(fuelBarDelay > 0)
        {
            fuelBarDelay--;
        }
        else
        {
            fb.currentCrystals--;
            fb.SetFuel(fb.currentCrystals);
            fuelBarDelay = initFuelBarDelay;
        }
    }

    void ResetBoosters()
    {
        b1Anim.SetBool("B1Boosted", false);
        b2Anim.SetBool("B2Boosted", false);
        b3Anim.SetBool("B3Boosted", false);
        b4Anim.SetBool("B4Boosted", false);

    }

    void Glitch()
    {
        int newRandomGlitchVersion = Random.Range(1, 5);
        glitchVersion = newRandomGlitchVersion;
        shipAnim.SetBool("IsGlitching", true);

    }

    void FixedUpdate()
    {
        if(fb.currentCrystals > 0)
        {
            Vector3 targetVelocity = new Vector2(horizontalAxis * Time.fixedDeltaTime * 10f, verticalAxis * Time.fixedDeltaTime * 10f);
            ship_rb.velocity = Vector3.SmoothDamp(ship_rb.velocity, targetVelocity, ref V3_Zero, floatiness);
        }
        ResetBoosters();
        shipAnim.SetBool("IsGlitching", false);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Ship Hit");
            Glitch();
        }
        if (other.gameObject.CompareTag("Crystal"))
        {
            glitchVersion = 0;
        }
    }

}
