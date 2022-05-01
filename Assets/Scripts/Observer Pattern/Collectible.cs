using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public static event Action<int> OnScoreChange;
    public static event Action OnSoundEffect;
    [SerializeField] private int score = 10;
    [SerializeField] private float disappearTime = 4;

    private void OnTriggerEnter(Collider other)
    {
        OnScoreChange?.Invoke(score);
        OnSoundEffect?.Invoke();
        HideCollectible();
    }

    private void HideCollectible()
    {
        LeanTween.scale(gameObject,Vector3.zero, disappearTime).setOnComplete(() =>
        {
            gameObject.SetActive(false);
        }); 
    }
}
