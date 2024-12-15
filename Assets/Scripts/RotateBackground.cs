using UnityEngine;

public class PlanetariumBackground : MonoBehaviour
{
    public float rotationSpeed = 0.1f;
    public float orbitRadius = 2f;
    public float orbitSpeed = 0.1f;

    private Vector2 centerPosition;
    private float angle = 0f;

    void Start()
    {
        centerPosition = Vector2.zero;
    }

    void Update()
    {
        angle += orbitSpeed * Time.deltaTime;
        float x = Mathf.Cos(angle) * orbitRadius;
        float y = Mathf.Sin(angle) * orbitRadius;
        transform.position = new Vector2(centerPosition.x + x, centerPosition.y + y);
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
