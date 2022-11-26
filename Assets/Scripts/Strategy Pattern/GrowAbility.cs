using UnityEngine;

namespace Strategy_Pattern
{
    public class GrowAbility: IAbility
    {
        void IAbility.Use(GameObject go)
        {
            go.transform.localScale += new Vector3(1, 1, 1);
        }

        void IAbility.Reverse(GameObject go)
        {
            go.transform.localScale -= new Vector3(1, 1, 1);
        }
    }
}