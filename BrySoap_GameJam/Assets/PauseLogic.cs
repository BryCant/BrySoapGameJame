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
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadPause()
    {
        pauseScreen.SetActive(true);
    }

    public void EndPause()
    {
        pauseScreen.SetActive(false);
    }

    public void LoadTut()
    {
        tutScreen.SetActive(true);
    }

    public void EndTut()
    {
        tutScreen.SetActive(false);
    }
}
