using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Item : MonoBehaviour, ICollectable
{
    public static event HandleItemCollected onItemCollected;
    public delegate void HandleItemCollected(ItemData item);

    public ItemData itemData;
    
    public void Collect()
    {
        onItemCollected?.Invoke(itemData);
    }

}
