using Object_Pooling_Pattern;
using Observer_Pattern;
using UI;
using UnityEngine;
using Utils;

namespace Managers
{
    public class UIManager : Singleton<UIManager>
    { 
        [SerializeField] private SpeechBubbleUI speechBubbleUI;

        private void OnEnable()
        {
            Collectible.OnInstructions += text =>
            {
                ShowSpeechBubbleUI(text);
                GameManager.Instance.FreezeTime();
            };
            StageController.OnInstructions += text =>
            {
                ShowSpeechBubbleUI(text);
                GameManager.Instance.FreezeTime();
            };

            BulletSpawner.OnFirstShoot += text =>
            {
                ShowSpeechBubbleUI(text);
                GameManager.Instance.FreezeTime();
            };
        }
        
        private void OnDisable()
        {
            Collectible.OnInstructions -= ShowSpeechBubbleUI;
            StageController.OnInstructions -= ShowSpeechBubbleUI;
        }

        public void ShowSpeechBubbleUI(string text)
        {
            speechBubbleUI.SetData(text).ToggleSpeechCanvas(true);
        }
    }
}
