using Cassa.Script;
using TMPro;
using UnityEngine;

namespace MenuFinale.Script
{
    public class SlidersScript : MonoBehaviour
    {
        public TextMeshProUGUI climateText;
        public TextMeshProUGUI walletText;
        public TextMeshProUGUI healthText;

        public UnityEngine.UI.Slider climateSlider;
        public UnityEngine.UI.Slider walletSlider;
        public UnityEngine.UI.Slider healthSlider;
        
        // Start is called before the first frame update
        public void Start()
        {
            // Disabilita l'interazione con gli slider
            climateSlider.interactable = false;
            walletSlider.interactable = false;
            healthSlider.interactable = false;
            
            climateSlider.onValueChanged.AddListener((v) =>
            {
                climateText.text = v.ToString("0"); 
            });
        
            walletSlider.onValueChanged.AddListener((v) =>
            {
                walletText.text = v.ToString("0");
            });
        
            healthSlider.onValueChanged.AddListener((v) =>
            {
                healthText.text = v.ToString("0");
            });
        
            if (CassaManagerScript.instance == null) return;
        
            climateSlider.value = CassaManagerScript.instance.climateIndicator;
            walletSlider.value = CassaManagerScript.instance.walletIndicator;
            healthSlider.value = CassaManagerScript.instance.healthIndicator;
        }
    
    }
}
