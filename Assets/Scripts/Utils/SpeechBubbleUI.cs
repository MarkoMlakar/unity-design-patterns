using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
    public class SpeechBubbleUI : MonoBehaviour
    {
        [SerializeField] private GameObject speechBubble;
        [SerializeField] private Transform transformToFollow;
        [SerializeField] private TMP_Text contentText;
        [SerializeField] private float textTypingSpeed;
        [SerializeField] private float delayBetweenTextChange;
        [SerializeField] private float delayBeforeClosing;


        private new Camera camera;
        private string currentText;
        public SpeechBubbleUI SetData(string textContent)
        {
            currentText = textContent;
            return this;
        }

        public void ToggleSpeechCanvas(bool toggle)
        {
            speechBubble.SetActive(toggle);
            if (toggle)
                StartCoroutine(SpeechTyper());
        }

        private IEnumerator SpeechTyper()
        {
            contentText.text = "";
            for (int i = 0; i < currentText.Length; i++)
            {
                // Pagination
                if (currentText[i] == '|')
                {
                    yield return new WaitForSeconds(delayBetweenTextChange);
                    contentText.text = "";
                    continue;
                }
                contentText.text += currentText[i];
                yield return new WaitForSeconds(textTypingSpeed);
            }
            
            // Hide bubble at the end
            yield return new WaitForSeconds(delayBeforeClosing);
            ToggleSpeechCanvas(false);
        }
        private void Start()
        {
            camera = Camera.main;
            speechBubble.SetActive(false);
        }

        private void Update()
        {
            speechBubble.transform.position = camera.WorldToScreenPoint(transformToFollow.position);
        }
    }
}
