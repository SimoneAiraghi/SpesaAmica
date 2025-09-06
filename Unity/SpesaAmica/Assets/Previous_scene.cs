using UnityEngine.SceneManagement;
using UnityEngine;

public class Previous_scene : MonoBehaviour
{
    //funzione chiamata quando viene premuto il tasto 'Select'
    public void CaricaScenaPrecedente()
    {
        //Caricamento della scena successiva
        SceneManager.LoadScene("Regole Gioco");
    }
}