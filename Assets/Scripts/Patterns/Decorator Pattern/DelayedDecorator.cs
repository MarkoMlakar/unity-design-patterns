using System.Threading.Tasks;
using Managers;
using Strategy_Pattern;
using UnityEngine;

namespace Decorator_Pattern
{
    public class DelayedDecorator : IAbility
    {
        private IAbility wrappedAbility;

        public DelayedDecorator(IAbility wrappedAbility)
        {
            this.wrappedAbility = wrappedAbility;
        }

        private async void DelayedUse(GameObject go, int delayDuration)
        {
            AudioManager.Instance.PlaySuperJump();
            await Task.Delay(delayDuration);
            Debug.Log("Delayed decorator in use");
            go.GetComponent<PlayerStyler>().SetBaseMaterialColor(new Color32(0,0,255,255));
            wrappedAbility.Use(go);
        }

        void IAbility.Use(GameObject go)
        {
            DelayedUse(go, 2000);
        }

        void IAbility.Reverse(GameObject go)
        {
            Debug.Log("Delayed decorator off");
            go.GetComponent<PlayerStyler>().SetBaseMaterialColor(new Color32(255,255,255,255));
            wrappedAbility.Reverse(go);
        }
    }
}
