using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    // Assicurati di assegnare un AudioClip a questa variabile nell'Inspector di Unity
    public AudioClip collectSound;

    public void Start()
    {
        // Assicurati che l'oggetto abbia un componente AudioSource
        if (GetComponent<AudioSource>() == null)
        {
            // Aggiungi un componente AudioSource se non è presente
            gameObject.AddComponent<AudioSource>();
        }
    }

    public void OnMouseDown()
    {
        ICollectable collectible = gameObject.GetComponent<ICollectable>();

        if (collectible != null)
        {
            // Raccogli l'oggetto
            collectible.Collect();
            
            // Riproduci il suono
            PlayCollectSound();
        }
    }

    public void PlayCollectSound()
    {
        // Assicurati che l'oggetto abbia un componente AudioSource
        AudioSource audioSource = GetComponent<AudioSource>();

        // Assegna il suono all'AudioSource
        audioSource.clip = collectSound;

        // Riproduci il suono
        audioSource.Play();
    }
}
