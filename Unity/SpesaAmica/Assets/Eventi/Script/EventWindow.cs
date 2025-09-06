using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace Eventi.Script
{
    public class EventWindow : MonoBehaviour
    {
        public TextMeshProUGUI eventText;
        
        public Button closeButton;

        public void DrawEvent(string text)
        {
            eventText.text = text;
        }

        public void Close()
        {
            Destroy(gameObject);
        }
    }
}
