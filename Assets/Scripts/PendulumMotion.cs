using UnityEngine;

public class PendulumMotion : MonoBehaviour
{
    public float swingDistance = 2f; // Maximum horizontal distance (along the Z-axis)
    public float verticalAmplitude = 0.5f; // Amplitude for the vertical motion (less vertical displacement)
    public float speed = 2f; // Speed of the pendulum motion
    private float time;
    private bool isSwinging = false;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Toggle swinging when the pendulum is clicked
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                isSwinging = !isSwinging;
            }
        }

        // If the pendulum is swinging
        if (isSwinging)
        {
            time += Time.deltaTime * speed;

            // Calculate horizontal motion (back and forth on the Z-axis)
            float offsetZ = Mathf.Cos(time) * swingDistance;

            // Calculate the vertical motion only for the bottom half of the swing
            float offsetY = Mathf.Abs(Mathf.Sin(time)) * verticalAmplitude;

            // Set the position, keeping the motion restricted to the bottom half of the circle
            transform.position = startPosition + new Vector3(0f, offsetY, offsetZ);
        }
    }
}
