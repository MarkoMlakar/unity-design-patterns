using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement
{
    [RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Controllers")]
        [SerializeField] private CharacterController characterController;
        [Header("Input controls")]
        [SerializeField] private PlayerInput playerInput;

        [Header("Movement Variables")] 
        [SerializeField] private float movementSpeed = 2f;
        [SerializeField] private float rotationSpeed = 5f;
        [SerializeField] private float jumpHeight = 2.5f;
        [Header("Ground Check")]
        [SerializeField] private float gravityValue = -9.81f;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundDistance = 0.4f;
        [SerializeField] private LayerMask groundMask;

        private bool isGroundedPlayer;
        private Vector3 playerVelocity;
        private Vector3 moveDirection;
        private InputAction moveAction;
        private InputAction jumpAction;
        private Transform cameraTransform;


        private void Start()
        {
            moveAction = playerInput.actions["Move"];
            jumpAction = playerInput.actions["Jump"];
            cameraTransform = Camera.main.transform;
        }

        void Update()
        {
            isGroundedPlayer = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (isGroundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = -2f; // force the player to the ground
            }

            // Move the player in relation of the camera direction
            Vector2 input = moveAction.ReadValue<Vector2>();
            moveDirection = new Vector3(input.x, 0, input.y);
            moveDirection = moveDirection.x * cameraTransform.right.normalized +
                            moveDirection.z * cameraTransform.forward.normalized;
            moveDirection.y = 0f;
            characterController.Move(moveDirection * Time.deltaTime * movementSpeed);
            
            // Rotate the player in relation of the camera direction
            float targetAngle = cameraTransform.eulerAngles.y;
            Quaternion targetRotation = Quaternion.Euler(0, targetAngle,0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            
            // Jump
            if (jumpAction.triggered && isGroundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }
            
            playerVelocity.y += gravityValue * Time.deltaTime;
            characterController.Move(playerVelocity * Time.deltaTime);
        }
    }
}
