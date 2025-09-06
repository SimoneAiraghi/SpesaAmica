using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RankScoreData : MonoBehaviour
{
    public static RankScoreData Instance;
    public List<int> scores;
    private const int RankSize = 5;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
            
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int score)
    {
        if (scores.Count <= 4)
        {
            scores.Add(score);
        }
        else
        {
            int min = scores.Min();
            if (score > min)
            {
                scores.Remove(min);
                scores.Add(score);
            }
        }
        scores.Sort();
        scores.Reverse();
    }

    public int GetMax()
    {
        return scores.Max();
    }
    
}
