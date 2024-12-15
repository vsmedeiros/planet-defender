using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform planet;
    private float speed;


    public void Initialize(Transform planetTransform, float moveSpeed)
    {
        planet = planetTransform;
        speed = moveSpeed;
    }

    private void Update()
    {
        if (planet != null)
        {
            Vector3 direction = (planet.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform == planet)
        {
            Destroy(gameObject);
        }
    }
}