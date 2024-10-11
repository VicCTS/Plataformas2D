using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Enemy : MonoBehaviour
{
    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlaySFX(_audioSource, SoundManager.instance.mimikAudio);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
