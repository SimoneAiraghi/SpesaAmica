using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestorePulsanti : MonoBehaviour
{
    //Recupero l'oggetto persistente contenente la variabile 'posizioneCorrente'
    private DatiCondivisi datiCondivisi;

    public Button pulsanteAvanti;
    public Button pulsanteIndietro;

    public Inventory inventoryScript;
    
    // Start is called before the first frame update
    void Start()
    {
        datiCondivisi = System.Array.Find(Resources.FindObjectsOfTypeAll<DatiCondivisi>(), obj => obj.hideFlags == HideFlags.None);
        datiCondivisi = DatiCondivisi.Instance;
        AggiornaStatoPulsanti();
        
        
        inventoryScript = Inventory.instance;
        // Assicurati che inventoryScript sia assegnato correttamente nella tua scena
        if (inventoryScript == null)
        {
            Debug.LogError("Inventory script not assigned to GestorePulsanti script.");
        }
    }
    
    //Metodo per gestire il click sul pulsante 'Avanti'
    public void PulsanteAvantiClick()
    {
        datiCondivisi.posizioneCorrente++;
        
        //Aggiorno lo stato dei pulsanti in funzione della nuova posizione
        AggiornaStatoPulsanti();
    }
    
    //Metod per gestire il click sul pulsante 'Indietro'
    public void PulsanteIndietroClick()
    {
        datiCondivisi.posizioneCorrente--;
        
        //Aggiorno lo stato dei pulsanti in funzione della nuova posizione
        AggiornaStatoPulsanti();
    }
    
    //Metodo per aggiornare la visibilità dei pulsanti in base alla posizione corrente 
    private void AggiornaStatoPulsanti()
    {
        int posizione = datiCondivisi.posizioneCorrente;

        if (posizione == 0)
        {
            //Nella prima schermata disattivo il pulsante 'Indietro'
            pulsanteIndietro.interactable = false;
            pulsanteAvanti.interactable = true; 
        }
        else if (posizione == 2)
        {
            //Nell'ultima schermata disattivo il pulsante 'Avanti'
            pulsanteAvanti.interactable = false;
            pulsanteIndietro.interactable = true; 
        }
        else
        {
            //Nella schermata intermedia attivo entrambi i pulsnati 
            pulsanteAvanti.interactable = true;
            pulsanteIndietro.interactable = true; 
        }
    }

    public void PulsanteFineSpesa()
    {
        if (inventoryScript.selectedItemsCount == 5)
        {
            datiCondivisi.posizioneCorrente = 0; 
            AggiornaStatoPulsanti();
        }
        
    }
}
