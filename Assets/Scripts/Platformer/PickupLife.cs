using UnityEngine;
using UnityStandardAssets._2D;

public class PickupLife : MonoBehaviour
{
    [Tooltip("Audio Clip to play on pickup.")]
    [SerializeField] private AudioClip sfx = null; // Audio Clip to play on pickup.

    [Tooltip("The message (method name) used with SendMessage. The message is sent to all script components attached to me (the pickup).")]
    [SerializeField] private string messageSelf = null; // The method name to call with SendMessage. The message is sent to all script components attached to me (the pickup).

    [Tooltip("The message (method name) used with SendMessage. The message is sent to all script components attached to the colliding GameObject (the player).")]
    [SerializeField] private string messageOther = null; // The method name to call with SendMessage. The message is sent to all script components attached to the colliding Game Object (the player).

    [Tooltip("The method name to call with BroadcastMessage. The message is sent to all script components and children attached to me (the pickup).")]
    [SerializeField] private string messageBroadcast = null; // The method name to call with BroadcastMessage. The message is sent to all script components and children attached to me (the pickup).

    [Tooltip("The GameObject to call SendMessage on. The message is sent to all script components attached to target.")]
    [SerializeField] private GameObject messageTarget = null; // The Game Object to call SendMessage on. The message is sent to all script components attached to target.

    [Tooltip("The method name to call with SendMessage. The message is sent to all script componenets attached to target (messageTarget).")]
    [SerializeField] private string messageTargetMessage = null; // The method name to call with SendMessage. The message is sent to all script componenets attached to target (messageTarget).

    private AudioSource sfxSource; // Reference to pickup's Audio Source component.
    private Health healthComponent; // Reference to the Health component


    void Awake()
    {
        // Get a reference to the pickup's audio source component.
        sfxSource = this.gameObject.GetComponent<AudioSource>();
        // If sound effects are specified and we have an audio source attached...
        if (sfx != null && sfxSource != null) sfxSource.clip = sfx; // ...set the audio clip on the audio source to our pickup sfx.

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        // Check if the other collider belongs to the player and get the PlatformerCharacter2D component
        PlatformerCharacter2D playerController = other.GetComponentInParent<PlatformerCharacter2D>();

        if (playerController != null)
        {
            // Only proceed if the collider is the one used for standing or crouching (whichever you prefer)
            if (other.CompareTag("Player"))
            {
                // Find the Score script on the Score GameObject and call AddScoreOnPickup method.
                GameObject healthComponent = GameObject.Find("HealthText");
                if (healthComponent != null)
                {
                    Health healthScript = healthComponent.GetComponent<Health>();
                    if (healthScript != null)
                    {
                        healthScript.AddHealthPickup();
                    }
                }
            }
            // Play sound effects if specified.
            if (sfx != null && sfxSource != null)
            {
                sfxSource.Play();
                // Disable the sprite renderer and collider to make it seem like the object is destroyed immediately.
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<Collider2D>().enabled = false;
                // Destroy the game object after the sound finishes playing.
                Destroy(gameObject, sfx.length);
            }
            else
            {
                Destroy(gameObject); // Destroy the pickup immediately if no sound is specified.
            }
        }
    }
}
