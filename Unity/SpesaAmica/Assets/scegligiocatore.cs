using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Nome della scena da caricare
    public string sceneToLoad = "scegligiocatore";

    // Metodo chiamato quando il pulsante viene premuto
    public void OnPlayButtonPressed()
    {
        // Carica la scena di gioco desiderata
        LoadScene();
    }

    // Metodo per il caricamento della scena
    private void LoadScene()
    {
        // Carica la scena utilizzando il nome della scena
        SceneManager.LoadScene(sceneToLoad);
    }
}
