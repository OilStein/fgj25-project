using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private const float maxPitch = 89f;
    private const float minPitch = -89f;

    public float Speed = 1f;
    public float SprintSpeed = 2f;

    public float XSensitivity = 1f;
    public float YSensitivity = 1f;

    public float JumpVerticalSpeed = 10;
    public float Gravity = -10;
    public float VerticalSpeedLimit = 20;

    [SerializeField]
    private new Transform camera;

    private CharacterController characterController;
    private PlayerInput playerInput;

    private float pitch = 0;
    private float yaw = 0;

    private bool isGrounded = false;

    private float verticalSpeed = 0;

    private Vector3 moveDirection;
    private float moveSpeed;

    public Vector3 CurrentMovement => moveSpeed * moveDirection +
        new Vector3(0, verticalSpeed, 0);

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        UpdateRotation();
        UpdateJump();
        UpdateMovement();
    }

    private bool IsTryingToJump()
        => playerInput.Actions.Jump.WasPerformedThisFrame();
    
    private bool IsTryingToSprint()
        => playerInput.Actions.Sprint.IsPressed();

    private void UpdateRotation()
    {
        var mouseDelta = playerInput.Actions.Look.ReadValue<Vector2>();

        pitch -= mouseDelta.y * YSensitivity;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        yaw += mouseDelta.x * XSensitivity;

        camera.localEulerAngles = new Vector3(pitch, yaw, 0);
    }

    private void UpdateJump()
    {
        if (isGrounded && IsTryingToJump())
        {
            verticalSpeed = JumpVerticalSpeed;
            isGrounded = false;
        }
    }

    private void UpdateMovement()
    {
        var moveInput = playerInput.Actions.Move.ReadValue<Vector2>();

        if (isGrounded)
        {
            var horizontalDirection = camera.right;
            horizontalDirection.y = 0;
            horizontalDirection.Normalize();
            var verticalDirection = camera.forward;
            verticalDirection.y = 0;
            verticalDirection.Normalize();
            moveDirection = horizontalDirection * moveInput.x + verticalDirection * moveInput.y;
            if (moveDirection != Vector3.zero)
            {
                moveDirection.Normalize();
            }
        }

        if (isGrounded)
        {
            moveSpeed = Speed;
            if (IsTryingToSprint())
            {
                moveSpeed = SprintSpeed;
            }
        }

        verticalSpeed += Gravity * Time.deltaTime;
        verticalSpeed = Mathf.Clamp(verticalSpeed, -VerticalSpeedLimit, VerticalSpeedLimit);

        var movement = CurrentMovement * Time.deltaTime;
        var collisionFlags = characterController.Move(movement);

        if (collisionFlags.HasFlag(CollisionFlags.Below))
        {
            verticalSpeed = -1f;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}