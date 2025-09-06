using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Kcal : MonoBehaviour
{
    public TextMeshProUGUI kcal;

    public void Start()
    {
        kcal.text = 0.ToString();
    }
    
    public void DecreaseKcal(int amount)
    { 
        int cost = Convert.ToInt32(kcal.text);
        cost = cost - amount;
        kcal.text = cost.ToString();
    }

    public void IncreaseKcal(int amount)
    { 
        int cost = Convert.ToInt32(kcal.text);
        cost = cost + amount;
        kcal.text = cost.ToString();
    }
}
