using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RewardSystem : MonoBehaviour
{
    //public Transform resetPoint;

    // Initiate Rewards
    public int MAX_CRYSTALS = 10;
    public GameObject gameOverScreen;

    public bool carryOn = true;


    public FuelBar fb;

    public AudioClip explosionSound;
    AudioSource mySound;

    private void Awake()
    {
        mySound = GetComponent<AudioSource>();
    }

    void Start()
    {
        fb.SetFuel(MAX_CRYSTALS);
    }

    private void Update()
    {
        if (fb.currentCrystals == 0 && carryOn)
        {
            StartCoroutine(GameOver());
            carryOn = false;
        }
    }

    IEnumerator GameOver() 
    {
        yield return new WaitForSeconds(1f);

        mySound.PlayOneShot(explosionSound, 0.4f);

        if (fb.currentCrystals == 0)
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
        /*else if (other.gameObject.CompareTag("Crystal") && fb.currentCrystals == 0)
        {
            
        }*/
    }
}
