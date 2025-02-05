using UnityEngine;

public class RotateOnClick : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float hangingSwingSpeed = 2f;
    public float hangingSwingAmount = 5f;
    private bool isSpinning = false;
    private float swingTime = 0f;
    private float currentRotationY = 0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                isSpinning = !isSpinning;
                if (!isSpinning)
                {
                    swingTime = 0f; // Reset swing when stopping
                }
            }
        }

        if (isSpinning)
        {
            // Update swing motion (only when spinning)
            swingTime += Time.deltaTime * hangingSwingSpeed;
            float swingOffset = Mathf.Sin(swingTime) * hangingSwingAmount;

            // Update rotation (spin around Y axis)
            currentRotationY += rotationSpeed * Time.deltaTime;
            Quaternion spinRotation = Quaternion.Euler(0, currentRotationY, 0);

            // Combine swinging and spinning: Apply the swinging around the X axis and spinning around Y axis
            transform.localRotation = Quaternion.Euler(swingOffset, 0, 0) * spinRotation;
        }
    }
}
