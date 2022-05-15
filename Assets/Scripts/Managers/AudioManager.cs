using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip diamondClip;
    
    private void OnEnable()
    {
        Collectible.OnCollision += PlayCollisionSound;
    }

    private void OnDisable()
    {
        Collectible.OnCollision -= PlayCollisionSound;
    }

    private void PlayCollisionSound()
    {
        audioSource.PlayOneShot(diamondClip);
    }
}
