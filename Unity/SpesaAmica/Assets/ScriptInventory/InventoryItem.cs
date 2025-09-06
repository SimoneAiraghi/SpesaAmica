using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

 [Serializable]
public class InventoryItem
{
    public ItemData itemData;

    public InventoryItem(ItemData item)
    {
        itemData = item;
    }
}
