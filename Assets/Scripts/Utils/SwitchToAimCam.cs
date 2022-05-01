using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Utils
{
    public class SwitchToAimCam : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private Canvas thirdPersonCanvas;
        [SerializeField] private Canvas aimCanvas;
        private InputAction aimAction;

        private void Awake()
        {
            aimAction = playerInput.actions["Aim"];
        }

        private void OnEnable()
        {
            aimAction.performed += _ => StartAim();
            aimAction.canceled += _ => CancelAim();
        }
        
        private void OnDisable()
        {
            aimAction.performed -= _ => StartAim();
            aimAction.canceled -= _ => CancelAim();
        }

        private void StartAim()
        {
            CameraManager.Instance.EnableAimCam();
            aimCanvas.enabled = true;
            thirdPersonCanvas.enabled = false;
        }

        private void CancelAim()
        {
            CameraManager.Instance.DisableAimCam();
            aimCanvas.enabled = false;
            thirdPersonCanvas.enabled = true;
        }
    }
}
