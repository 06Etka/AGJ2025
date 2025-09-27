using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Character Movement")]
    [Tooltip("Movement speed of the character")]
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 moveInput;    
    private Vector3 moveDirection;
    private Vector3 velocity;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void SetPlayerVelocity()
    {
        moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        velocity = moveDirection * moveSpeed * Time.deltaTime;
    }

    void MovePlayer()
    {
        controller.Move(velocity);
    }

    void Update()
    {
        SetPlayerVelocity();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }
}


