using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip diamondClip;
    
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
