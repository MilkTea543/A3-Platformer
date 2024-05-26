using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class Pickup : MonoBehaviour
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

    void Awake()
    {
        // get a reference to the pickup's audio source component.
        sfxSource = this.gameObject.GetComponent<AudioSource>();
        // if sound effects are specified and we have a audio source attached...
        if (sfx != null && sfxSource != null) sfxSource.clip = sfx; // ...set the audio clip on audio source to our pickup sfx.
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // play sound effects if specified.
        if (sfx != null && sfxSource != null) sfxSource.Play();

        // Check if the other collider belongs to the player and get the PlatformerCharacter2D component
        PlatformerCharacter2D playerController = other.GetComponentInParent<PlatformerCharacter2D>();

        if (playerController != null)
        {
            // Only proceed if the collider is the one used for standing or crouching (whichever you prefer)
            if (other.CompareTag("Player"))
            {
                IngredientManager.Instance.CollectIngredient(gameObject);

                // Find the Score script on the Score GameObject and call AddScoreOnPickup method.
                GameObject scoreObject = GameObject.Find("ScoreText");
                if (scoreObject != null)
                {
                    Score scoreScript = scoreObject.GetComponent<Score>();
                    if (scoreScript != null)
                    {
                        scoreScript.AddScoreOnPickup();
                    }
                }
            }

            // Send messages as requested
            if (messageOther != "") other.SendMessage(messageOther); // send a message to all scripts attached to other (the player / thing doing the picking up),
            if (messageSelf != "") SendMessage(messageSelf); // send a message to all scripts attached to me (the pickup),
            if (messageBroadcast != "") BroadcastMessage(messageBroadcast); // send a message to all scripts attached to me and any children,
            if (messageTarget != null && messageTargetMessage != "") messageTarget.SendMessage(messageTargetMessage); // send a message to a particular game object.

            // Destroy the pickup
            if (sfx != null && sfxSource != null)
            {
                Destroy(this); // Destroy this script component.
                gameObject.GetComponent<SpriteRenderer>().enabled = false; // Disable the sprite.
                Destroy(gameObject, sfx.length); // Destroy the pickup after the sfx audio length.
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}