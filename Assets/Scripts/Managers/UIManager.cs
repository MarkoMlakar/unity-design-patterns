using UI;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    { 
        public static UIManager Instance { get; private set; }
        [SerializeField] private SpeechBubbleUI speechBubbleUI;
        [SerializeField] private TextAsset bubbleText;

        public void ShowSpeechBubbleUI()
        {
            speechBubbleUI.SetData(bubbleText.text).ToggleSpeechCanvas(true);
        }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }
    }
}
