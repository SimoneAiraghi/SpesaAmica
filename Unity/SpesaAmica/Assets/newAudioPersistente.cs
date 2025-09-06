using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    /*
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("AudioManager").AddComponent<AudioManager>();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }
    */

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private AudioSource audioSource;
    public AudioClip song;  // Assegna l'AudioClip desiderato nell'Inspector di Unity

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = song;
        audioSource.loop = true;  // Loop della canzone
        audioSource.Play();
    }
}