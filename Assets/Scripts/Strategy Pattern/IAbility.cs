using UnityEngine;

namespace Strategy_Pattern
{
    public interface IAbility
    {
        void Use(GameObject go);
        void Reverse(GameObject go);
    }
}