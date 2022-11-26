using UnityEngine;

namespace Strategy_Pattern
{ 
    public class FireAbility: MonoBehaviour, IAbility
    {
        [SerializeField] private ParticleSystem fireAbilityParticles;
        void IAbility.Use(GameObject go)
        {
            Debug.Log("Use fire ability on gameobject: " + go.name);
            fireAbilityParticles.Play();
        }

        void IAbility.Reverse(GameObject go)
        {
            Debug.Log("Fire ability OFF");
            fireAbilityParticles.Stop();
        }
    }
}