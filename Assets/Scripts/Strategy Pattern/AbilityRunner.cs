using UnityEngine;
using UnityEngine.InputSystem;

namespace Strategy_Pattern
{
    public class AbilityRunner : MonoBehaviour
    {
        [Header("Input controls")]
        [SerializeField] private PlayerInput playerInput;

        [SerializeField] private FireAbility fireAbilityObject;
        private InputAction fireAction;
        private InputAction growActionPositive;
        private InputAction growActionNegative;
        private InputAction superJumpAction;
        private IAbility fireAbility;
        private IAbility superJumpAbility;
        private IAbility growAbility;

        private bool _isFireAbilityOn;
        private bool _isSuperJumpAbilityOn;

        private void Start()
        {
            fireAction = playerInput.actions["FireAbility"];
            growActionPositive = playerInput.actions["GrowAbilityPositive"];
            growActionNegative = playerInput.actions["GrowAbilityNegative"];
            superJumpAction = playerInput.actions["SuperJumpAbility"];
        }

        private void Update()
        {
            if (fireAction.WasPerformedThisFrame())
                UseFireAbility(gameObject, !_isFireAbilityOn);
            if (growActionPositive.WasPerformedThisFrame())
                UseGrowAbility(gameObject, true);
            if (growActionNegative.WasPerformedThisFrame())
                UseGrowAbility(gameObject, false);
            if(superJumpAction.WasPerformedThisFrame())
                UseSuperJumpAbility(gameObject, !_isSuperJumpAbilityOn);
        }

        private void UseSuperJumpAbility(GameObject go, bool isOn)
        {
            _isSuperJumpAbilityOn = isOn;
            superJumpAbility ??= new SuperJumpAbility();
            if(isOn)
                superJumpAbility.Use(go);
            else
                superJumpAbility.Reverse(go);
            
        }

        private void UseFireAbility(GameObject go, bool isOn)
        {
            _isFireAbilityOn = isOn;
            fireAbility ??= fireAbilityObject;
            if(isOn)
                fireAbility.Use(go);
            else
                fireAbility.Reverse(go);
            
        }

        private void UseGrowAbility(GameObject go, bool isOn)
        {
            growAbility ??= new GrowAbility();
            if(isOn)
                growAbility.Use(go);
            else
                growAbility.Reverse(go);
        }
    }
}
