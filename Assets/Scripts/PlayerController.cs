using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 9f;
    public float stopDistance = 1f;

    private bool _canMove = true;
    private CharacterController _controller;
    private PlayerInputActions _inputActions;
    private Vector2 _moveInput;

    private Vector3 _tapTarget;
    private bool _hasTapTarget = false;

    private Camera _cam;

    void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _inputActions = new PlayerInputActions();
        _cam = Camera.main;
    }

    void OnEnable()
    {
        _inputActions.Player.Enable();
        _inputActions.Player.Move.performed += OnMove;
        _inputActions.Player.Move.canceled += OnMoveStopped;
    }

    void OnDisable()
    {
        _inputActions.Player.Move.performed -= OnMove;
        _inputActions.Player.Move.canceled -= OnMoveStopped;
        _inputActions.Player.Disable();
    }

    void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
        _hasTapTarget = false; // keyboard overrides tap
    }

    void OnMoveStopped(InputAction.CallbackContext context)
    {
        _moveInput = Vector2.zero;
    }

    void Update()
    {
        if (!_canMove) return;

        DetectTap();

        Vector3 moveDirection = Vector3.zero;

        if (_moveInput != Vector2.zero)
        {
            
            moveDirection = new Vector3(_moveInput.x, 0, _moveInput.y);
        }
        else if (_hasTapTarget)
        {
            
            Vector3 toTarget = _tapTarget - transform.position;
            toTarget.y = 0;

            if (toTarget.magnitude > stopDistance)
            {
                moveDirection = toTarget.normalized;
            }
            else
            {
                _hasTapTarget = false; // arrived
            }
        }

        _controller.Move(moveDirection * moveSpeed * Time.deltaTime);
        _controller.Move(Vector3.down * 9.81f * Time.deltaTime);

        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }
    }

    void DetectTap()
    {
        bool tapped = false;
        Vector2 screenPos = Vector2.zero;

      
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            tapped = true;
            screenPos = Touchscreen.current.primaryTouch.position.ReadValue();
        }
       
        else if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            tapped = true;
            screenPos = Mouse.current.position.ReadValue();
        }

        if (tapped && _cam != null)
        {
            Ray ray = _cam.ScreenPointToRay(screenPos);
            if (Physics.Raycast(ray, out RaycastHit hit, 1000f))
            {
                _tapTarget = hit.point;
                _hasTapTarget = true;
            }
        }
    }

    public void SetInputEnabled(bool enabled)
    {
        _canMove = enabled;
    }
}