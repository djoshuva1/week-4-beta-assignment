using UnityEngine;

public class SwingOnClick : MonoBehaviour
{
    public float swingSpeed = 2f; // Speed of the swinging motion
    public float swingAmount = 30f; // How much the object swings (degrees)
    public float rotationSpeed = 100f; // Speed of rotation when clicked

    private bool isSwinging = false;  // Whether the object is swinging or not
    private float swingTime = 0f;     // Timer to track the swing motion
    private float currentRotationY = 0f; // Track rotation around Y-axis

    private Quaternion initialRotation; // The initial rotation of the object when it's not swinging

    void Start()
    {
        // Save the initial rotation of the object so we can reset it when needed
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // Detect mouse click on the object
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                // Toggle swinging on/off
                isSwinging = !isSwinging;

                if (!isSwinging)
                {
                    // Optionally reset swing state when stopping
                    swingTime = 0f;
                    currentRotationY = 0f;
                    transform.rotation = initialRotation; // Reset to the initial rotation
                }
            }
        }

        if (isSwinging)
        {
            // Pendulum-style swinging effect
            swingTime += Time.deltaTime * swingSpeed;
            float swingOffset = Mathf.Sin(swingTime) * swingAmount;

            // Apply swing effect around the Z-axis (more natural "hanging" look)
            Quaternion swingRotation = Quaternion.Euler(0, 0, swingOffset);

            // Apply rotation effect around the Y-axis
            currentRotationY += rotationSpeed * Time.deltaTime;
            Quaternion rotation = Quaternion.Euler(0, currentRotationY, 0);

            // Combine swing (on Z-axis) and rotation (on Y-axis)
            transform.rotation = swingRotation * rotation;
        }
    }
}
