using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class FuelBar : MonoBehaviour
{

    public GameObject[] batteries;

    public int currentCrystals = 10;

    public void SetFuel(int fuelNum)
    {
        currentCrystals = fuelNum;
        if(fuelNum < (batteries.Length + 1)) { 
            for(int i = 0; i < batteries.Length; i++)
            {
                    if(i < fuelNum)
                    {
                        batteries[i].SetActive(true);
                    }
                    else
                    {
                        batteries[i].SetActive(false);
                    }
            }
        }
    }

}
