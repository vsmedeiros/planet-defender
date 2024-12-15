using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = .5f;
    public float rotationSpeed = 100f;
    private void Update()
    {
        Transform childTransform = transform.Find("Sprite");
        childTransform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        transform.Translate(Vector2.up * speed * Time.deltaTime); // Move o projétil
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetParameters(float speed, float lifetime, float rotationSpeed)
    {
        this.speed = speed;
        this.lifetime = lifetime;
        this.rotationSpeed = rotationSpeed;
    }

    public float CalculateMaxDistance()
    {
        return speed * lifetime;
    }
}