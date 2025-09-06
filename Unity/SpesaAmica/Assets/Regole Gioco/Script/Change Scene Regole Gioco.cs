using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneRegoleGioco : MonoBehaviour
{
    //funzione chiamata quando viene premuto il tasto 'Select'
    public void CaricaScenaSuccessiva()
    {
        //Caricamento della scena successiva
        SceneManager.LoadScene("Scaffali");
    }
    
    public void CaricaScenaPrecedente()
    {
        //Caricamento della scena precedente
        SceneManager.LoadScene("Selezione Giocatore"); 
    }
    
}
