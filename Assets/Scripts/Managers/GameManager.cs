using System.Collections;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(2);
            
            UIManager.Instance.ShowSpeechBubbleUI("Hello friend! My name is Marko|Welcome to my sandbox!|Happy exploring \n :=)");
        }
    }
}
