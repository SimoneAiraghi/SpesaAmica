using System.Collections;
using System.Collections.Generic;
using Cassa.Script;
using Eventi.Script;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public AudioClip clip;
    
    public void Restart()
    {
        PersistentSound.Instance.ChangeSong(clip);
        CassaManagerScript.instance.ResetIndicators();
        EventData.Instance.ResetEvents();
        SceneManager.LoadScene("Selezione Giocatore");
    }
}
