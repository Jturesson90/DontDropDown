using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WaterSplash : MonoBehaviour
{
    public float AudioPitchLow = 1f;
    public float AudioPitchHigh = 1f;
    public List<AudioClip> AudioClips;


    private ParticleSystem _splashParticle;
    private AudioSource _audioSource;

    private void Awake()
    {
        _splashParticle = GetComponent<ParticleSystem>();
        _audioSource = GetComponent<AudioSource>();
    }
    public void Splash()
    {
        _audioSource.pitch = Random.Range(AudioPitchLow, AudioPitchHigh);
        _audioSource.PlayOneShot(AudioClips[Random.Range(0, AudioClips.Count)], 1f);

        _splashParticle.Play();
    }
}
