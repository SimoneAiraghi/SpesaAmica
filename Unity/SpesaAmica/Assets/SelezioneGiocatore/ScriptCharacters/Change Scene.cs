using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    //funzione chiamata quando viene premuto il tasto 'Select'
    public void CaricaScenaSuccessiva()
    {
        //Caricamento della scena successiva
        SceneManager.LoadScene("Regole Gioco");
    }
}
