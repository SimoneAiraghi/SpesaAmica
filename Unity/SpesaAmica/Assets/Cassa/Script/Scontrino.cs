using System;
using TMPro;
using UnityEngine;

namespace Cassa.Script
{
    public class Scontrino : MonoBehaviour
    { 
        // Riferimento all'oggetto Text che mostrerà lo scontrino
        public  TextMeshProUGUI scontrinoText;

        public void Start()
        {
            StampaScontrino();
        }

        // Stampa lo scontrino
        private void StampaScontrino()
        {
            if (Inventory.instance == null) return;
            
            int totale = 0;
            // Creazione della stringa dello scontrino
            string scontrino = "";
            foreach (InventoryItem prodotto in Inventory.instance.inventory)
            {
                scontrino += prodotto.itemData.displayName + "  " + "$" + prodotto.itemData.cost + "\n";
                totale = totale + prodotto.itemData.cost;
            }
        

            // Visualizza lo scontrino nel Text
            scontrino += "\nTotale: $" + totale.ToString("F2"); // Aggiungi la riga del totale

            scontrinoText.text = scontrino;
        
            //totaleText.text = "Totale: $" + totale.ToString("F2"); // Aggiorna il campo del totale
        }
    }
}
