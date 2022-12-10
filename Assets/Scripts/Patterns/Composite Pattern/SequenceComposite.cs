using Strategy_Pattern;
using UnityEngine;

namespace Composite_Pattern
{
    public class SequenceComposite : IAbility
    {
        private IAbility[] children;

        public SequenceComposite(IAbility[] children)
        {
            this.children = children;
        }
        void IAbility.Use(GameObject go)
        {
            foreach (var child in children)
            {
                child.Use(go);
            }
            Debug.Log("Composite pattern in use");
        }
        void IAbility.Reverse(GameObject go)
        {
            foreach (var child in children)
            {
                child.Reverse(go);
            }
        }
    }   
}
