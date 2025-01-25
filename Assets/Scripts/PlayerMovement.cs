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

    private float pitch = 0;
    private float yaw = 0;

    private bool isGrounded = false;

    private float verticalSpeed = 0;

    private Vector3 moveDirection;
    private float moveSpeed;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        UpdateRotation();
        UpdateJump();
        UpdateMovement();
    }

    private bool IsTryingToJump()
        => Input.GetButtonDown(GameConstants.Input.Jump);
    
    private bool IsTryingToSprint()
        => Input.GetButton(GameConstants.Input.Run);

    private void UpdateRotation()
    {
        var mouseDelta = Input.mousePositionDelta;

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
        var horizontal = Input.GetAxisRaw(GameConstants.Input.Horizontal);
        var vertical = Input.GetAxisRaw(GameConstants.Input.Vertical);

        if (isGrounded)
        {
            var horizontalDirection = camera.right;
            horizontalDirection.y = 0;
            horizontalDirection.Normalize();
            var verticalDirection = camera.forward;
            verticalDirection.y = 0;
            verticalDirection.Normalize();
            moveDirection = horizontalDirection * horizontal + verticalDirection * vertical;
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
        var verticalMovement = new Vector3(0, verticalSpeed * Time.deltaTime, 0);

        var movement = moveDirection * moveSpeed * Time.deltaTime + verticalMovement;
        var collisionFlags = characterController.Move(movement);

        if (collisionFlags.HasFlag(CollisionFlags.Below))
        {
            verticalSpeed = 0;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}