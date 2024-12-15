using UnityEngine;

public class RotateAroundCircle2D : MonoBehaviour
{
    public float radius = 5f; // Radius of the circular path
    public float speed = 50f; // Speed of rotation in degrees per second
    private float angle; // Current angle in degrees

    private void Update()
    {
        angle -= speed * Time.deltaTime; // Increment the angle based on speed
        if (angle >= 360f) angle -= 360f; // Keep the angle within 0-360 degrees

        // Calculate the new position
        float x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
        float y = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;

        // Update the transform position
        transform.position = new Vector3(x, y, transform.position.z);

        // Rotate the transform to face the center (0,0)
        float rotationAngle = angle -90f; // Adjust by 90 degrees to ensure the top points to the center
        transform.rotation = Quaternion.Euler(0, 0, rotationAngle);
    }
}
