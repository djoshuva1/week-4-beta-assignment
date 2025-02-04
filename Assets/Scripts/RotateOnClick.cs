using UnityEngine;

public class RotateOnClick : MonoBehaviour
{
    // Rotation speed in degrees per second
    public float rotationSpeed = 100f;

    // Called when the object is clicked
    private void OnMouseDown()
    {
        // Start rotating the object
        StartCoroutine(RotateSphere());
    }

    // Coroutine to handle the rotation
    private System.Collections.IEnumerator RotateSphere()
    {
        // Rotate the object continuously while the mouse button is held down
        while (Input.GetMouseButton(0))  // 0 is the left mouse button
        {
            // Rotate the object along the Y-axis
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            yield return null;  // Wait for the next frame
        }
    }
}