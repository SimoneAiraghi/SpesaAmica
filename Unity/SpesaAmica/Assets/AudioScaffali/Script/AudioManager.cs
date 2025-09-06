using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager2 : MonoBehaviour
{
    public AudioClip clip;

    public void Start()
    {
        if(PersistentSound.Instance != null)
            PersistentSound.Instance.ChangeSong(clip);
    }
}
