using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance {get; private set;}

    AudioSource _sfxAudioSource;

    [SerializeField]private AudioClip deathSound;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        _sfxAudioSource = GetComponent<AudioSource>();
    }

    public void DeathSound()
    {
        _sfxAudioSource.PlayOneShot(deathSound);
    }
}
