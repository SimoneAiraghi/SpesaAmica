using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class SpesaFinita : MonoBehaviour
{
    // Riferimento al tuo script Inventory
    public Inventory inventoryScript;
    public GameObject notifyWindow;
    public Button Buttonendshop;
    
    private void Start()
    {
        inventoryScript = Inventory.instance;
        // Assicurati che inventoryScript sia assegnato correttamente nella tua scena
        if (inventoryScript == null)
        {
            Debug.LogError("Inventory script not assigned to SpesaFinita script.");
        }
        //else
        //{
            // Disabilita il bottone all'inizio
          //  Buttonendshop.gameObject.SetActive(false);
       // }
    }

    public void ScenaSuccessiva()
    {
        //Debug.Log("Selected Items Count: " + inventoryScript.selectedItemsCount);

        if (inventoryScript.selectedItemsCount == 5)
        {
            //Debug.Log("Enabling Button");
            //Buttonendshop.gameObject.SetActive(true);
            SceneManager.LoadScene("cassa");
        }
        else
        {
            GameObject textobj = notifyWindow.transform.GetChild (0).gameObject;
            TextMeshProUGUI mytext = textobj.GetComponent<TextMeshProUGUI>();
            mytext.text = "You need to select 5 items";
            notifyWindow.SetActive(true);
            //Debug.Log("Disabling Button");
            //Buttonendshop.gameObject.SetActive(false);
        }
    
    }
}