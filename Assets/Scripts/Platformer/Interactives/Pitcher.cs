using UnityEngine;

public class Pitcher : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;
    public float fireRate = 1f;
    public float nextFireTime;
    public float activationDistance = 10f; // Distance at which the pitcher starts shooting

    private Transform player; // Reference to the player object

    void Start()
    {
        // Find the player object by tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Check if the player is within the activation distance
        if (Vector2.Distance(transform.position, player.position) <= activationDistance)
        {
            // Calculate the direction to the player
            Vector2 direction = (player.position - transform.position).normalized;

            // Calculate the angle of the direction
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Rotate the firePoint to face the player
            firePoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Shoot the bullet
            if (Time.time > nextFireTime)
            {
                Shoot(direction);
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }

    void Shoot(Vector2 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(direction.normalized * bulletForce, ForceMode2D.Impulse);
    }

}
