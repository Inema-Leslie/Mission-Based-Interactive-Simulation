using UnityEngine;
using UnityEngine.InputSystem;

// This script moves Kagabo around the world

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    // Movement speed — you can change this in the Inspector
    public float moveSpeed = 9f;

    // Is the player allowed to move right now?
    private bool _canMove = true;

    // These are set automatically
    private CharacterController _controller;
    private PlayerInputActions _inputActions;
    private Vector2 _moveInput;

    void Awake()
    {
        // Get the CharacterController on this GameObject
        _controller = GetComponent<CharacterController>();

        // Set up the input system
        _inputActions = new PlayerInputActions();
    }

    void OnEnable()
    {
        // Start listening for input
        _inputActions.Player.Enable();
        _inputActions.Player.Move.performed += OnMove;
        _inputActions.Player.Move.canceled  += OnMoveStopped;
    }

    void OnDisable()
    {
        // Stop listening for input
        _inputActions.Player.Move.performed -= OnMove;
        _inputActions.Player.Move.canceled  -= OnMoveStopped;
        _inputActions.Player.Disable();
    }

    // Called when player presses a movement key
    void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    // Called when player releases movement key
    void OnMoveStopped(InputAction.CallbackContext context)
    {
        _moveInput = Vector2.zero;
    }

    void Update()
    {
        // Only move if movement is allowed
        if (!_canMove) return;

        // Convert 2D input to 3D movement (top-down)
        Vector3 moveDirection = new Vector3(_moveInput.x, 0, _moveInput.y);

        // Move the character
        _controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Apply gravity so Kagabo stays on the ground
        _controller.Move(Vector3.down * 9.81f * Time.deltaTime);

        // Rotate Kagabo to face the direction he's moving
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }
    }

    // Call this to stop or allow player movement
    public void SetInputEnabled(bool enabled)
    {
        _canMove = enabled;
    }
}