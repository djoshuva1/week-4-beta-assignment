using UnityEngine;

public class MoveBackAndForthOnClick : MonoBehaviour
{
    public float moveSpeed = 2f;        // Speed at which the object moves back and forth
    public float moveDistance = 5f;     // The maximum distance the object will move on the Z-axis
    private bool isMoving = false;      // Flag to control whether the object is moving
    private float startZPosition;       // The initial position of the object on the Z-axis
    private float moveTime = 0f;        // Timer to control movement over time

    void Start()
    {
        // Record the initial Z position of the object
        startZPosition = transform.position.z;
    }

    void Update()
    {
        // Check for mouse click (left click)
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast to check if the object was clicked
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                // Toggle movement on and off
                isMoving = !isMoving;

                // Optionally, reset the position if the movement stops
                if (!isMoving)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, startZPosition);
                }
            }
        }

        // If the object is moving, apply back-and-forth motion
        if (isMoving)
        {
            moveTime += Time.deltaTime * moveSpeed; // Increment the move time

            // Calculate the oscillation along the Z-axis using a sine wave
            float offset = Mathf.Sin(moveTime) * moveDistance;

            // Set the object's position, keeping the X and Y constant but modifying the Z position
            transform.position = new Vector3(transform.position.x, transform.position.y, startZPosition + offset);
        }
    }
}

