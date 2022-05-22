using System;
using Observer_Pattern;
using UnityEngine;

namespace Utils
{
    public class StageController : MonoBehaviour
    {
        public static event Action<string> OnInstructions; 
        [SerializeField] private TextAsset instructions;
        [SerializeField] private GameObject lights;

        private int numberOfVisits;
        private void OnTriggerEnter(Collider other)
        {
            numberOfVisits++;
            if(numberOfVisits == 1)
                OnInstructions?.Invoke(instructions.text);
        }

        private void OnEnable()
        {
            StageInteractable.OnInteract += _ =>
            {
                lights.SetActive(true);
            };
            StageInteractable.NotInteract += () =>
            {
                lights.SetActive(false);
            };
        }
    }
}
