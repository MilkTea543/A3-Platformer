using UnityEngine;

public class Vines : MonoBehaviour
{
    public float climbSpeed = 3f;
    public Transform climbPoint;

    private bool isPlayerInRange;
    private Rigidbody2D playerRigidbody;

    void Start()
    {
        playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isPlayerInRange)
        {
            float verticalInput = Input.GetAxisRaw("Vertical");

            if (verticalInput != 0)
            {
                Vector2 climbVelocity = new Vector2(playerRigidbody.velocity.x, verticalInput * climbSpeed);
                playerRigidbody.velocity = climbVelocity;
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                // Climb up the ladder
                Vector2 climbVelocity = new Vector2(playerRigidbody.velocity.x, climbSpeed);
                playerRigidbody.velocity = climbVelocity;
            }
            else
            {
                // Stop climbing
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            // Stop climbing when leaving the ladder
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0f);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (climbPoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, climbPoint.position);
        }
    }
}
