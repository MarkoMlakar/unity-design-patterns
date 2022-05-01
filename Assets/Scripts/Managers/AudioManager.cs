using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip diamondClip;
    private void Awake()
    {
        if (Instance != null && Instance == this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void OnEnable()
    {
        Collectible.OnSoundEffect += PlayCollisionSound;
    }

    private void OnDisable()
    {
        Collectible.OnSoundEffect -= PlayCollisionSound;
    }

    private void PlayCollisionSound()
    {
        audioSource.PlayOneShot(diamondClip);
    }
}
