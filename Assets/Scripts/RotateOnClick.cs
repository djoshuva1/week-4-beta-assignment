using UnityEngine;

public class RotateOnClick : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float hangingSwingSpeed = 2f;
    public float hangingSwingAmount = 5f;
    private bool isSpinning = false;
    private float swingTime = 0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                isSpinning = !isSpinning;
            }
        }

        if (isSpinning)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // Simulate a hanging effect by swinging back and forth
        swingTime += Time.deltaTime * hangingSwingSpeed;
        float swingOffset = Mathf.Sin(swingTime) * hangingSwingAmount;
        transform.localRotation = Quaternion.Euler(swingOffset, transform.localRotation.eulerAngles.y, 0);
    }
}