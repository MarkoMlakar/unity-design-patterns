using System;
using State_Pattern;
using UnityEngine;

namespace Observer_Pattern
{
    public class StageInteractable: MonoBehaviour
    {
        public static event Action<DanceType> OnInteract;
        public static event Action NotInteract;

        [SerializeField] private DanceType type;
        [SerializeField] private Material selectedMaterial;
        [SerializeField] private Material defaultMaterial;

        private MeshRenderer renderer;
        private void Start()
        {
            renderer = gameObject.GetComponent<MeshRenderer>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            OnInteract?.Invoke(type);
            renderer.material = selectedMaterial;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            NotInteract?.Invoke();
            renderer.material = defaultMaterial;
        }
    }
}