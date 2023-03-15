using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 20f; // The speed at which the object should rotate
    private Vector3 rotationVector; // The vector that holds the rotation values for the object

    private void Start()
    {
        // Set the initial rotation vector of the object
        rotationVector = new Vector3(0f, 0f, rotationSpeed);
    }

    private void Update()
    {
        // Rotate the object around its y-axis by the rotation speed
        transform.Rotate(rotationVector * Time.deltaTime);
    }
}
