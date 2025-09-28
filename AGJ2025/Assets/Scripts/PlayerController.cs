using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    /// <summary> Constant Float representing <c>0f</c> to eliminate magic numbers </summary>
    private const float fZero = 0f;

    [Header("Character Movement")]
    [Tooltip("Movement speed of the character")]
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 moveInput;    
    private Vector3 moveDirection;
    private Vector3 velocity;
    private CharacterController controller;

    [Header("Graphics Settings")]
    [Tooltip("Reference to the character's graphics object")]
    [SerializeField] private GameObject graphicsObject;
    private PlayerAnimator playerAnimator;

    private GraphicsDirectionHandler graphicsDirectionHandler;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        graphicsDirectionHandler = new(graphicsObject);
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    /// <summary> Only gets the input value, ensure this is run under the update method </summary>
    void SetPlayerVelocity()
    {
        moveDirection = new Vector3(moveInput.x, fZero, fZero);
        velocity = moveDirection * moveSpeed * Time.deltaTime;
    }

    void MovePlayer()
    {
        controller.Move(velocity);
    }

    void HandleAnimations()
    {
        if (moveInput.x != fZero)
        {
            playerAnimator.SetAnimationState(PlayerAnimationState.Walking);
        }
        else
        {
            playerAnimator.SetAnimationState(PlayerAnimationState.Idle);
        }
    }

    private void Update()
    {
        SetPlayerVelocity();

        if (graphicsObject != null)
        {
            graphicsDirectionHandler.ApplyDirection(moveInput.x);
            MovePlayer();
            HandleAnimations();
        }
    }
}


