using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InfoScript
{
    public class ItemInfo : MonoBehaviour
    {
        public TextMeshProUGUI infoMessage;
        public Image icon;
    
        public void DrawInfoBox(ItemData itemData)
        {
            icon.sprite = itemData.icon;
            infoMessage.enabled = true;
            infoMessage.text = "Name: " + itemData.displayName + "\nCost: " + itemData.cost.ToString() + "$" + "\nkcal: " + itemData.kcal;
        }
    
    
    }
}
