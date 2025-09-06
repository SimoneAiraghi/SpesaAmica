using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remover : MonoBehaviour
{
    public AudioClip removeSound;

    /*public AudioSource audioSource; */


    public void Start()
    {
        // Assicurati che l'oggetto abbia un componente AudioSource
        if (GetComponent<AudioSource>() == null)
        {
            // Aggiungi un componente AudioSource se non è presente
            gameObject.AddComponent<AudioSource>();
        }
        
    }


    public void OnMouseClick()
    {
        InventorySlot removible = gameObject.GetComponent<InventorySlot>();
        
        if (removible != null && removible.data != null)
        {
            removible.Remove();
        }
    }

   
}
