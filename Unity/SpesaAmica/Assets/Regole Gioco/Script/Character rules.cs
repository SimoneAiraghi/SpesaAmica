using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class Characterrules : MonoBehaviour
{
    public TextMeshProUGUI testoDescrizione;

    void Start()
    {
        int indicePersonaggio = PlayerPrefs.GetInt("SelectedCharacterIndex", 0);
        StartCoroutine(MostraDescrizionePersonaggio(indicePersonaggio));
    }

    IEnumerator MostraDescrizionePersonaggio(int indicePersonaggio)
    {
        string description = "";

        switch (indicePersonaggio)
        {
            case 0:
                //SCETTICI 
                description = "<b>Welcome to SpesaAmica!<b> \n You're in a world grappling with unstoppable changes, navigating a digital supermarket where the air is heavy. The world suffers around you, and every product you choose impacts the fate of this struggling world and all of humanity! Your daily shopping must balance caloric needs with eco-friendly choices, all within a limited budget. Your indifference may amplify suffering, but thoughtful choices offer hope. See how your decisions shape your virtual world; you might even reconsider your stance on climate change. Choose wisely—the future of our planet is in your hands, but survival is key!\r\n<b>Challenges:</b> \n\n Ensure your cart's total calories are at least 650. \n\n Budget wisely with 70 dollars.\n\n Make impactful, sustainable choices!\r\n";
                break;
            case 1:
                description = "<b>Welcome to SpesaAmica!<b> \n Embark on a virtual shopping journey where your food choices impact your health and the environment. Be mindful in this everyday supermarket, where each product influences your well-being and surroundings. Make wise choices, balancing caloric needs with environmental considerations, all while managing a limited budget. Witness how your decisions shape outcomes. Happy conscious shopping!\r\n<b>Challenges:</b>\n\nEnsure your cart's total calories are at least 650.\r\nBudget wisely with 70 dollars.\n\n Make impactful, sustainable choices!\n\n";
                break;
            case 2:
                description = "<b> Welcome to SpesaAmica!<b> \n Immerse yourself in a virtual shopping journey emphasizing the impact of daily choices on the planet. In your favorite sustainable supermarket, choose products that respect the environment. Each item in your cart affects your health, the climate, and your budget. Strive for balance between personal well-being and environmental sustainability. See how your choices shape a more eco-friendly world, proving small deeds matter. Don't worry; we can make a difference! Happy green shopping!\r\n<b>Challenges:</b>\r\nEnsure your cart's total calories are at least 650.\n\nBudget wisely with 70 dollars. Make impactful, sustainable choices!\r\n";
                break;
            default:
                break;
        }

        for (int i = 0; i < description.Length; i++)
        {
            testoDescrizione.text = description.Substring(0, i);
            yield return new WaitForSeconds(0.08f); // Adjust the delay time as needed
        }
    }
}
