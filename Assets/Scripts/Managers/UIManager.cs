using UnityEngine;
using Utils;

namespace Managers
{
    public class UIManager : MonoBehaviour
    { 
        public static UIManager Instance { get; private set; }
        [SerializeField] private SpeechBubbleUI speechBubbleUI;

        public void ShowSpeechBubbleUI(string textContent)
        {
            speechBubbleUI.SetData(textContent).ToggleSpeechCanvas(true);
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
