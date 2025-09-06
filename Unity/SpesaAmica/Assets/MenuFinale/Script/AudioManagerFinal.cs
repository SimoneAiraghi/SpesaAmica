using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerFinal : MonoBehaviour
{
    public AudioClip clip;
    
    public void Start()
    {
        PersistentSound.Instance.PlaySongOneTime(clip);
    }
}
