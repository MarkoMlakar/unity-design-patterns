using System.Collections;
using UnityEngine;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(2);
            UIManager.Instance.ShowSpeechBubbleUI();
        }
    }
}
