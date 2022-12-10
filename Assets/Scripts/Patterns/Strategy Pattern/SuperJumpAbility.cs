using Movement;
using UnityEngine;

namespace Strategy_Pattern
{
    public class SuperJumpAbility: IAbility
    {

        private float _lastHeight;
        void IAbility.Use(GameObject go)
        {
            Debug.Log("Use super jump on gameobject: " + go.name);
            go.GetComponent<PlayerMovement>().JumpHeight += 5;
        }

        void IAbility.Reverse(GameObject go)
        {
            Debug.Log("Super jump OFF");
            go.GetComponent<PlayerMovement>().JumpHeight = 2.5f;
        }
    }
}