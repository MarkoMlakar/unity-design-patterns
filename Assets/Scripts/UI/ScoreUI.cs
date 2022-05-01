using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreUI: MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        private int score { get; set; }

        private void Start()
        {
            scoreText.text = score.ToString();
        }

        private void OnEnable()
        {
            Collectible.OnScoreChange += OnCollectible;
        }

        private void OnDisable()
        {
            Collectible.OnScoreChange -= OnCollectible;
        }
        private void OnCollectible(int amount)
        {
            score += amount;
            scoreText.text = score.ToString();
        }
    }
}