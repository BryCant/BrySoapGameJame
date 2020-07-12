using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseLogic : MonoBehaviour
{
    public GameObject tutScreen;

    public void Restart()
    {
        SceneManager.LoadScene(1);
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
