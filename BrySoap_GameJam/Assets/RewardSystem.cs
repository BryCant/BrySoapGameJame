using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    //public Transform resetPoint;

    // Initiate Rewards
    public int MAX_CRYSTALS = 10;
    public GameObject gameOverScreen;


    public FuelBar fb;


    void Start()
    {
        fb.SetFuel(MAX_CRYSTALS);
    }

    IEnumerator GameOver() 
    {
        yield return new WaitForSeconds(4f);
        if(fb.currentCrystals == 0)
        {
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Crystal") && fb.currentCrystals < MAX_CRYSTALS)
        {
            fb.currentCrystals++;
            fb.SetFuel(fb.currentCrystals);
        }
        else if (other.gameObject.CompareTag("Crystal") && fb.currentCrystals == 0)
        {
            StartCoroutine(GameOver());
        }
    }
}
