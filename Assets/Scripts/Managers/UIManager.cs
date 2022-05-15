using UI;
using UnityEngine;

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
        }
        
        private void OnDisable()
        {
            Collectible.OnInstructions -= ShowSpeechBubbleUI;
        }

        public void ShowSpeechBubbleUI(string text)
        {
            speechBubbleUI.SetData(text).ToggleSpeechCanvas(true);
        }
    }
}
