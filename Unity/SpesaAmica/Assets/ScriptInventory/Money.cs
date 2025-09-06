using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using Cassa.Script;

public class Money : MonoBehaviour
{
    public TextMeshProUGUI wallet;

    public void Start()
    {
        if (CassaManagerScript.instance != null)
        {
            int cost = CassaManagerScript.instance.walletIndicator;
            wallet.text = cost.ToString();
        }
        else
        {
            wallet.text = "70";
        }
    }

    public int GetMoney()
    {
        return Convert.ToInt32(wallet.text);
    }

    public void DecreaseMoney(int amount)
    { 
        int cost = Convert.ToInt32(wallet.text);
        cost = cost - amount;
        wallet.text = cost.ToString();
    }

    public void IncreaseMoney(int amount)
    { 
        int cost = Convert.ToInt32(wallet.text);
        cost = cost + amount;
        wallet.text = cost.ToString();
    }
}
