using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    // Rotation speed for automatic rotation
    public Vector3 rotationSpeed = new Vector3(0, 50, 0);
    
    // Toggle for user input rotation
    public bool allowUserInput = true;

    // Input sensitivity
    public float inputSensitivity = 100f;

    void Update()
    {
        // Automatic rotation
        transform.Rotate(rotationSpeed * Time.deltaTime);

        // User input for rotation
        if (allowUserInput)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 inputRotation = new Vector3(vertical, horizontal, 0) * inputSensitivity * Time.deltaTime;
            transform.Rotate(inputRotation, Space.World);
        }
    }
}
