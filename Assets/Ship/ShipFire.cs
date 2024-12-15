using UnityEngine;

public class ShipFire : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab do projétil
    public Transform firePoint; // Ponto de onde o projétil será disparado

    private float nextFireTime = 0f;

    public float fireRate = 0.5f; // Taxa de disparo em segundos


    public float speed = 10f;
    public float lifetime = .5f;
    public float rotationSpeed = 100f;
    private Animator animator;


    public void Start()
    {
        animator = GetComponentInChildren<Animator>();

    }
    private void Update()
    {
        bool spacePressed = Input.GetKey(KeyCode.Space);
        if (Time.time >= nextFireTime && spacePressed)
        {
            animator.SetBool("IsShotting", true);
            Shoot();
            nextFireTime = Time.time + fireRate; // Atualiza o tempo para o próximo disparo
        }
        else
        {
            animator.SetBool("IsShotting", false);
        }
    }

    private void Shoot()
    {
        var projectileInstance = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Projectile projectileScript = projectileInstance.GetComponent<Projectile>();
        projectileScript.SetParameters(speed, lifetime, rotationSpeed);
    }
}