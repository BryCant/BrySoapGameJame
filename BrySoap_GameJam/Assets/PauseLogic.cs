using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseLogic : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject tutScreen;

    public void GoHome()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void LoadPause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void EndPause()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    public void LoadTut()
    {
        Time.timeScale = 0;
        tutScreen.SetActive(true);
    }

    public void EndTut()
    {
        Time.timeScale = 0;
        tutScreen.SetActive(false);
    }

}
