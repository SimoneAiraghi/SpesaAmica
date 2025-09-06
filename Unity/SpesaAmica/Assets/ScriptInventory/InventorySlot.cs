using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InventorySlot : MonoBehaviour
{
    public static event HandleItemRemoved onItemRemoved;
    public delegate void HandleItemRemoved(ItemData item);
    
    public Image icon;
    public TextMeshProUGUI labelText;

    public ItemData data;
    //public TextMeshProUGUI stackSizeText;

    public void Remove()
    {
        onItemRemoved?.Invoke(data);
    }
    
    public void ClearSlot()
    {
        icon.enabled = false;
        labelText.enabled = false;
        //stackSizeText.enabled = false;
    }
    
    public void DrawSlot(InventoryItem item)
    {
        if (item == null)
        {
            ClearSlot();
            return;
        }
        
        icon.enabled = true;
        labelText.enabled = true;
        
        
        icon.sprite = item.itemData.icon;
        labelText.text = item.itemData.displayName;
        data = item.itemData;
        //stackSizeText = item.stackSize.ToString();
    }
}
