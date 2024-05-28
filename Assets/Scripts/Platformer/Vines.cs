using UnityEngine;

public class Vines : MonoBehaviour
{
    public float climbSpeed = 3f;
    public Transform climbPoint;
    public Animator playerAnimator;

    private bool isPlayerInRange;
    private Rigidbody2D playerRigidbody;
    private AudioSource vineAudioSource;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerRigidbody = player.GetComponent<Rigidbody2D>();
        playerAnimator = player.GetComponent<Animator>();
        vineAudioSource = GetComponentInChildren<AudioSource>();
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

                // Set IsClimbing parameter in animator
                playerAnimator.SetBool("IsClimbing", true);
                playerAnimator.SetBool("IsIdle", false);
                playerAnimator.SetBool("IsCrouching", false);

                // Play vine climbing sound
                if (!vineAudioSource.isPlaying)
                {
                    vineAudioSource.Play();
                }
            }
            else
            {
                // Maintain the climb animation even if the player is stationary on the vine
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0f);

                // Stop vine climbing sound if player is stationary
                if (vineAudioSource.isPlaying)
                {
                    vineAudioSource.Stop();
                }
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
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0f);

            // Set IsClimbing to false to stop climbing animation
            playerAnimator.SetBool("IsClimbing", false);
            playerAnimator.SetBool("IsIdle", true);
            playerAnimator.SetBool("IsCrouching", true);

            // Stop vine climbing sound
            if (vineAudioSource.isPlaying)
            {
                vineAudioSource.Stop();
            }
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
