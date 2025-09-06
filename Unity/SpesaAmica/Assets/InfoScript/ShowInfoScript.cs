using System;
using UnityEngine;

namespace InfoScript
{
    public class ShowInfoScript : MonoBehaviour
    {

        public GameObject info;
        public GameObject infoBox;
    
        public void OnMouseOver()
        { 
            info.SetActive(true);
            Item item = gameObject.GetComponent<Item>();
            ItemData data = item.itemData;
        
            ItemInfo infoComponent= infoBox.GetComponent<ItemInfo>();
            infoComponent.DrawInfoBox(data);
        }

        public void OnMouseExit()
        {
            info.SetActive(false);
        }
    }
}
