using UnityEngine;

public class OrbitOnClick : MonoBehaviour
{
    public Transform orbitCenter; // The object it will orbit around
    public float orbitRadius = 5f;
    public float orbitSpeed = 50f;
    private bool isOrbiting = false;
    private float angle = 0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                isOrbiting = !isOrbiting;
            }
        }

        if (isOrbiting && orbitCenter != null)
        {
            angle += orbitSpeed * Time.deltaTime;
            float x = orbitCenter.position.x + Mathf.Cos(angle * Mathf.Deg2Rad) * orbitRadius;
            float z = orbitCenter.position.z + Mathf.Sin(angle * Mathf.Deg2Rad) * orbitRadius;
            transform.position = new Vector3(x, transform.position.y, z);
        }
    }
}
