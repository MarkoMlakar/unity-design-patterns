using UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement
{
    [RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
    public class PlayerMovement : MonoBehaviour
    {
        private static readonly int s_MoveX = Animator.StringToHash("MoveX");
        private static readonly int s_MoveZ = Animator.StringToHash("MoveZ");
        
        [Header("Controllers")]
        [SerializeField] private CharacterController characterController;

        [Header("Input controls")]
        [SerializeField] private PlayerInput playerInput;
        
        [Header("Movement Variables")] 
        [SerializeField] private float movementSpeed = 2f;
        [SerializeField] private float rotationSpeed = 5f;
        public float JumpHeight = 2.5f;
        
        [Header("Ground Check")]
        [SerializeField] private float gravityValue = -9.81f;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundDistance = 0.4f;
        [SerializeField] private LayerMask groundMask;

        [Header("Animations")] 
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private float animationSmoothTime = 0.1f;

        private bool isGroundedPlayer;
        private Vector3 playerVelocity;
        private Vector3 moveDirection;
        private InputAction moveAction;
        private InputAction jumpAction;
        private Transform cameraTransform;
        private Vector2 currentAnimationBlendVector;
        private Vector2 animationVelocity;
        private void Awake()
        {
            playerAnimator.SetFloat(s_MoveX,0);
            playerAnimator.SetFloat(s_MoveZ,0);
        }

        private void Start()
        {
            moveAction = playerInput.actions["Move"];
            jumpAction = playerInput.actions["Jump"];
            cameraTransform = Camera.main.transform;
            Cursor.lockState = CursorLockMode.Locked;
            playerInput.DeactivateInput();
        }

        private void OnEnable()
        {
            SpeechBubbleUI.OnSpeechBubbleClose += EnableInput;
            SpeechBubbleUI.OnSpeechBubbleOpen += DisableInput;
        }

        private void OnDisable()
        {
            SpeechBubbleUI.OnSpeechBubbleClose -= EnableInput;
            SpeechBubbleUI.OnSpeechBubbleOpen -= DisableInput;

        }
        
        private void EnableInput()
        {
            playerInput.ActivateInput();
        }

        private void DisableInput()
        {
            playerInput.DeactivateInput();
        }

        private void Update()
        {
            isGroundedPlayer = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (isGroundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = -2f; // force the player to the ground
            }

            // Move the player in relation of the camera direction
            Vector2 input = moveAction.ReadValue<Vector2>();
            
            // Blend with animations
            currentAnimationBlendVector = Vector2.SmoothDamp(currentAnimationBlendVector, input, 
                ref animationVelocity, animationSmoothTime);
            
            moveDirection = new Vector3(currentAnimationBlendVector.x, 0, currentAnimationBlendVector.y);
            moveDirection = moveDirection.x * cameraTransform.right.normalized +
                            moveDirection.z * cameraTransform.forward.normalized;
            moveDirection.y = 0f;
            characterController.Move(moveDirection * Time.deltaTime * movementSpeed);
            
            // Animation
            playerAnimator.SetFloat(s_MoveX, currentAnimationBlendVector.x);
            playerAnimator.SetFloat(s_MoveZ, currentAnimationBlendVector.y);
            
            // Rotate the player in relation of the camera direction
            float targetAngle = cameraTransform.eulerAngles.y;
            Quaternion targetRotation = Quaternion.Euler(0, targetAngle,0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            
            // Jump
            if (jumpAction.triggered && isGroundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(JumpHeight * -3.0f * gravityValue);
            }
            
            playerVelocity.y += gravityValue * Time.deltaTime;
            characterController.Move(playerVelocity * Time.deltaTime);
        }
    }
}
