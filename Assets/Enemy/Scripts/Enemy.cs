using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public ParticleSystem deathParticles;
    private SpriteRenderer spriteRenderer;

    public Color damageColor = Color.red;
    public float flashDuration = 0.1f;
    private GameObject planet;
    private Color originalColor;


    public float totalLife = 100f;

    private float currentLife;
    public float velocity = 1f;

    private GameManager gameManager; // Referência ao GameManager


    private void Awake()
    {
        planet = GameObject.FindGameObjectWithTag("Planet");
        currentLife = totalLife;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Die()
    {
        // Vector2 hitDirection = (transform.position - planet.transform.position).normalized;

        // float angle = Mathf.Atan2(hitDirection.y, hitDirection.x) * Mathf.Rad2Deg;

        // Quaternion rotation = Quaternion.Euler(0, 0, angle);

        Instantiate(deathParticles, transform.position, Quaternion.identity);

        gameManager.EnemyKilled();

        Destroy(gameObject);
    }

    private IEnumerator FlashDamage()
    {
        // Mudar a cor para a cor de dano
        spriteRenderer.color = damageColor;

        // Esperar pela duração do flash
        yield return new WaitForSeconds(flashDuration);

        // Voltar à cor original
        spriteRenderer.color = originalColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
            currentLife -= 100f;
            StartCoroutine(FlashDamage());

            if (currentLife <= 0)
            {
                Die();
                return;

            }


        }
    }
}
