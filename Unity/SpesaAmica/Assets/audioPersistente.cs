using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentSound : MonoBehaviour
{
    public AudioClip persistentAudioClip;

    public AudioSource audioSource;

    public static PersistentSound Instance;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    
    public void Start()
    {
        if (audioSource != null) return;
        
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = persistentAudioClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void ChangeSong(AudioClip audioClip)
    {
        persistentAudioClip = audioClip;
        audioSource.loop = true;
        audioSource.clip = persistentAudioClip;
        audioSource.Play();
    }

    public void PlaySongOneTime(AudioClip audioClip)
    {
        persistentAudioClip = audioClip;
        audioSource.loop = false;
        audioSource.clip = persistentAudioClip;
        audioSource.Play();
    }

    /*
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex > 2)
        {
            // Se la scena è la quarta o successiva, distruggi l'oggetto audio persistente
            Destroy(gameObject);
        }
    }
    */
}




