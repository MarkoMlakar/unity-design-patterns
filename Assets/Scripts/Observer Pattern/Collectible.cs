using System;
using Managers;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public static event Action<int> OnScoreChange;
    public static event Action OnCollision;
    public static event Action<string> OnInstructions; 
    [SerializeField] private int score = 10;
    [SerializeField] private float disappearTime = 4;
    [SerializeField] private TextAsset instructions;

    private void OnTriggerEnter(Collider other)
    {
        OnScoreChange?.Invoke(score);
        OnCollision?.Invoke();

        if(GameManager.Instance.NumberOfCollectibles == 0)
        {
            OnInstructions?.Invoke(instructions.text);
        }
        
        HideCollectible();
        
        GameManager.Instance.NumberOfCollectibles++;
    }

    private void HideCollectible()
    {
        LeanTween.scale(gameObject,Vector3.zero, disappearTime).setOnComplete(() =>
        {
            gameObject.SetActive(false);
        }); 
    }
}
