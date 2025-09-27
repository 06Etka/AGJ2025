using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Character Movement")]
    [Tooltip("Movement speed of the character")]
    [SerializeField] private float moveSpeed = 5f;
    Vector2 moveInput;    
    Vector3 moveDirection;
    Vector3 velocity;
    CharacterController controller;

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
        moveDirection = new Vector3(moveInput.x, 0f, 0f);
        velocity = moveDirection * moveSpeed * Time.deltaTime;
    }

    void MovePlayer()
    {
        controller.Move(velocity);
    }

    void FixedUpdate()
    {
        SetPlayerVelocity();
        MovePlayer();
    }
}


