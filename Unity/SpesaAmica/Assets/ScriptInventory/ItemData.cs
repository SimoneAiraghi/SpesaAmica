using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    public string displayName;
    public Sprite icon;
    public int cost;
    public int climate;
    public int kcal;

    public void IncrementCost(int increment)
    {
        this.cost += increment;
    }

    public void SetCost(int newCost)
    {
        this.cost = newCost;
    }
}
