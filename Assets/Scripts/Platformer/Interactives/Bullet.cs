using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;   // Speed of the bullet
    public float activationDistance = 10f;  // Distance at which the bullet starts moving
    private Transform player;   // Reference to the player object
    private bool activated;     // Flag to indicate if the bullet is activated

    void Start()
    {
        // Find the player object by tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Check if the bullet is not yet activated and the player is within the activation distance
        if (!activated && Vector2.Distance(transform.position, player.position) <= activationDistance)
        {
            // Activate the bullet and start moving
            activated = true;
            Vector2 direction = (player.position - transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If the bullet hits the player, destroy itself
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            // add damage logic here
            // Example: other.gameObject.GetComponent<PlatformerCharacter2D>().TakeDamage();
        }
    }
}
