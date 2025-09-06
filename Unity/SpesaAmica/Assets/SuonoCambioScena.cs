using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SuonoCambioScena : MonoBehaviour
{
    public AudioClip clickSound;  // L'audio clip da riprodurre
    public string sceneDaCaricare;  // Il nome della scena da caricare
    private AudioSource audioSource;

    void Start()
    {   
        // Aggiungi un componente AudioSource a questo oggetto
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clickSound;  // Assegna l'audio clip

        // Ottieni il componente del bottone e aggiungi la funzione di callback
        UnityEngine.UI.Button button = GetComponent<UnityEngine.UI.Button>();
        if(button != null)
            button.onClick.AddListener(CaricaScenaSuccessiva);

        // Disabilita temporaneamente il componente AudioSource per evitare la riproduzione automatica
        audioSource.enabled = false;
    }

    // Funzione chiamata quando viene premuto il bottone
    void CaricaScenaSuccessiva()
    {
        audioSource.enabled = true;
        
        // Riproduci il suono
        audioSource.Play();

        // Ritarda il cambio scena di un breve lasso di tempo (puoi personalizzare il valore)
        Invoke("CambiaScena", 0.5f);
    }

    // Funzione per il cambio scena
    void CambiaScena()
    {
        SceneManager.LoadScene(sceneDaCaricare);
    }
}