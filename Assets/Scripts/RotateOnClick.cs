using UnityEngine;

public class RotateOnClick : MonoBehaviour
{
    public float rotationSpeed = 100f;
    private bool isSpinning = false;

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
    }
}