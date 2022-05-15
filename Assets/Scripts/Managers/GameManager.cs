using System;
using System.Collections;
using UI;
using UnityEngine;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private TextAsset initialSpeechText;
        
        public int NumberOfCollectibles { get; set; }
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(2);
            UIManager.Instance.ShowSpeechBubbleUI(initialSpeechText.text);
        }

        private void OnEnable()
        {
            SpeechBubbleUI.OnSpeechBubbleClose += ResumeTime;
        }
        
        private void OnDisable()
        {
            SpeechBubbleUI.OnSpeechBubbleClose -= ResumeTime;
        }

        public void FreezeTime()
        {
            Time.timeScale = 0;
        }

        public void ResumeTime()
        {
            Time.timeScale = 1;
        }
    }
}
