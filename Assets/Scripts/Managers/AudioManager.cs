using State_Pattern;
using UnityEngine;

namespace Managers
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip diamondClip;
        [SerializeField] private AudioClip backgroundClip;
        [SerializeField] private AudioClip breakDanceClip;
        [SerializeField] private AudioClip chickenDanceClip;
        [SerializeField] private AudioClip sexyDanceClip;
        [SerializeField] private AudioClip superJumpActivationClip;

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

        public void PlayClip(AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }

        public void PlaySuperJump()
        {
            audioSource.PlayOneShot(superJumpActivationClip);
        }

        public void ChangeStageMusic(DanceType type)
        {
            audioSource.volume = 0.2f;
            audioSource.Stop();
            switch (type)
            {
                case DanceType.Sexy:
                    audioSource.clip = sexyDanceClip;
                    break;
                case DanceType.BreakDance:
                    audioSource.clip = breakDanceClip;
                    break;
                case DanceType.ChickenDance:
                    audioSource.clip = chickenDanceClip;
                    break;
                case DanceType.Idle:
                    StopStageMusic();
                    break;
            }
            audioSource.Play();

        }

        private void StopStageMusic()
        {
            audioSource.Stop();
            audioSource.clip = backgroundClip;
            audioSource.loop = true;
            audioSource.volume = 1f;
            audioSource.Play();

        }
    }
}
