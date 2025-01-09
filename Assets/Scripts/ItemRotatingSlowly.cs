using UnityEngine;

public class ItemRotatingSlowly : MonoBehaviour
{
    // Speed of rotation
    public float rotationSpeed = 20f;

    void Update()
    {
        // Rotate the object around its Y-axis
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
