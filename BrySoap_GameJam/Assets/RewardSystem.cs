using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    //public Transform resetPoint;

    // Initiate Rewards
    public int MAX_CRYSTALS = 10;


    public FuelBar fb;


    void Start()
    {
        fb.SetFuel(MAX_CRYSTALS);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Crystal") && fb.currentCrystals < MAX_CRYSTALS)
        {
            fb.currentCrystals++;
            fb.SetFuel(fb.currentCrystals);
        }
    }
}
