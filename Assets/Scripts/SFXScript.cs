using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXScript : MonoBehaviour
{

    public AudioSource SFXSource, typingSFXSource;

    public AudioClip typingSound1;
    // Start is called before the first frame update

    public static SFXScript instance;
    private void Awake()
    {
        if (instance != null)
        { Debug.LogWarning("careful more than one SFX is present"); return; }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
     //  SFXSource = GetComponent<AudioSource>();
    }

    public void LaunchSoundSFX(AudioClip audio)
    {
        SFXSource.clip = audio;
        SFXSource.Play();
    }

    public void StartTypingSFX(AudioClip audio)
    {
        typingSFXSource.clip = audio;
        typingSFXSource.Play(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
