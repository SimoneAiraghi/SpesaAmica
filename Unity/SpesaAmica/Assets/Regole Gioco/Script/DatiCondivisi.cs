using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatiCondivisi : MonoBehaviour
{
    //Dichiaro una variabile che condivido con la scena successiva per tenere traccia della 
    //posizione corrente tra i tre reparti e gestire quindi la visibilità dei pulsanti
    public int posizioneCorrente;
    public static DatiCondivisi Instance;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
