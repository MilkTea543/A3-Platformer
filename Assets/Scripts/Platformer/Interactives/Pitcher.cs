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
    private bool isAlive = true; // Flag to track if the enemy is alive

    private AudioSource audioSource;
    public AudioClip nearPlayerSound;


    void Start()
    {
        // Find the player object by tag
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Load the near player sound
        audioSource.clip = nearPlayerSound;
    }

    void Update()
    {
        if (!isAlive)
        {
            return; // If the enemy is dead, exit the Update method
        }

        // Check if the player is within the activation distance
        if (Vector2.Distance(transform.position, player.position) <= activationDistance)
        {
            // Play the near player sound
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

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
        else
        {
            // Stop the near player sound if the player is not within range
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    void Shoot(Vector2 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(direction.normalized * bulletForce, ForceMode2D.Impulse);
    }

    public void Die()
    {
        isAlive = false;
        // Add any additional code you need to handle the enemy's death
    }
}
