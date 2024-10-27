using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXScript : MonoBehaviour
{

    public AudioSource SFXSource;
    public AudioSource typingSFXSource, motorSFXSource;

    public AudioClip typingSound1,motorSound;

    public static AudioSource moneySound, eatingSounds;

    [SerializeField] private Rigidbody2D playerRb;
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
        typingSFXSource = GameObject.Find("SFXManager/TypingAudio").GetComponent<AudioSource>();

        moneySound = GameObject.Find("SFXManager/Money sound").GetComponent<AudioSource>();
        moneySound.volume = 0.3f;

        eatingSounds = GameObject.Find("SFXManager/Eating sounds").GetComponent<AudioSource>();
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
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            motorSFXSource.volume = 0.6f;
        }
        else { motorSFXSource.volume = 0; }
    }
}
