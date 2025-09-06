using System;
using System.Collections;
using System.Collections.Generic;
using Cassa.Script;
using TMPro;
using UnityEngine;

public class RankManager : MonoBehaviour
{
    public RankScoreData scoreData;
    public CassaManagerScript indicatorsData;

    public TextMeshProUGUI first;
    public TextMeshProUGUI rank;

    public void Start()
    {
        indicatorsData = CassaManagerScript.instance;
        scoreData = RankScoreData.Instance;
        
        scoreData.AddScore(ComputeScores());
        DrawRank();
    }

    private int ComputeScores()
    {
        return (100 - indicatorsData.climateIndicator) + indicatorsData.healthIndicator +
               indicatorsData.walletIndicator;
    }

    public void DrawRank()
    {
        first.text = scoreData.GetMax().ToString();
        
        string text = "";
        for (int i = 1; i < scoreData.scores.Count; i++)
        {
            text += (i + 1) + ":   " + scoreData.scores[i] + "\n";
        }

        rank.text = text;
    }
    
}
