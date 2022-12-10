using Composite_Pattern;
using Decorator_Pattern;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Strategy_Pattern
{
    public class AbilityRunner : MonoBehaviour
    {
        [Header("Input controls")] [SerializeField]
        private PlayerInput playerInput;

        [SerializeField] private FireAbility fireAbilityObject;
        private InputAction fireAction;
        private InputAction growActionPositive;
        private InputAction growActionNegative;
        private InputAction superJumpAction;
        private InputAction sequenceAction;

        private IAbility fireAbility;
        private IAbility superJumpAbility;
        private IAbility growAbility;
        private IAbility sequenceAbility;

        private bool _isFireAbilityOn;
        private bool _isSuperJumpAbilityOn;
        private bool _isSequenceOn;

        private void Start()
        {
            fireAction = playerInput.actions["FireAbility"];
            growActionPositive = playerInput.actions["GrowAbilityPositive"];
            growActionNegative = playerInput.actions["GrowAbilityNegative"];
            superJumpAction = playerInput.actions["SuperJumpAbility"];
            sequenceAction = playerInput.actions["SequenceAbility"];
            
            growAbility = new GrowAbility();
            superJumpAbility = new DelayedDecorator(new SuperJumpAbility()); // Decorator pattern
            fireAbility = fireAbilityObject;
            sequenceAbility = new SequenceComposite(new[]
            {
                fireAbility,
                superJumpAbility,
                growAbility
            });
        }

        private void Update()
        {
            if (fireAction.WasPerformedThisFrame())
                UseFireAbility(gameObject, !_isFireAbilityOn);
            if (growActionPositive.WasPerformedThisFrame())
                UseGrowAbility(gameObject, true);
            if (growActionNegative.WasPerformedThisFrame())
                UseGrowAbility(gameObject, false);
            if (superJumpAction.WasPerformedThisFrame())
                UseSuperJumpAbility(gameObject, !_isSuperJumpAbilityOn);
            if (sequenceAction.WasPerformedThisFrame())
                UseSequenceAbility(gameObject, !_isSequenceOn);
        }

        private void UseSuperJumpAbility(GameObject go, bool isOn)
        {
            _isSuperJumpAbilityOn = isOn;
            if (isOn)
                superJumpAbility.Use(go);
            else
                superJumpAbility.Reverse(go);
        }

        private void UseFireAbility(GameObject go, bool isOn)
        {
            _isFireAbilityOn = isOn;
            if (isOn)
                fireAbility.Use(go);
            else
                fireAbility.Reverse(go);
        }

        private void UseGrowAbility(GameObject go, bool isOn)
        {
            if (isOn)
                growAbility.Use(go);
            else
                growAbility.Reverse(go);
        }

        private void UseSequenceAbility(GameObject go, bool isOn)
        {
            _isSequenceOn = isOn;
            if(isOn)
                sequenceAbility.Use(go);
            else
                sequenceAbility.Reverse(go);
            
        }
    }
}