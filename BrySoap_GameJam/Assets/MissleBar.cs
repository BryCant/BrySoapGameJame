using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class MissleBar : MonoBehaviour
{

    public GameObject[] missles;

    public int currentMissiles = 5;


    public void SetMissile(int missleNum)
    {
        currentMissiles = missleNum;
        if (missleNum < (missles.Length + 1))
        {
            for (int i = 0; i < missles.Length; i++)
            {
                if (i < missleNum)
                {
                    missles[i].SetActive(true);
                }
                else
                {
                    missles[i].SetActive(false);
                }
            }
        }
    }


}
