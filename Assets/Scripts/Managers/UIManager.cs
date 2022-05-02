using UI;
using UnityEngine;

namespace Managers
{
    public class UIManager : Singleton<UIManager>
    { 
        [SerializeField] private SpeechBubbleUI speechBubbleUI;
        [SerializeField] private TextAsset bubbleText;
        
        

        public void ShowSpeechBubbleUI()
        {
            speechBubbleUI.SetData(bubbleText.text).ToggleSpeechCanvas(true);
        }
    }
}
