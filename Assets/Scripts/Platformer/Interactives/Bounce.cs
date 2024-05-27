using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [Tooltip("The Vector 2 (x,y) force to apply using AddForce on trigger enter.")]
    [SerializeField] private Vector2 bounceForce = new Vector2(0f, 500f); // The Vector 2 (x,y) force to apply using AddForce.
    [Tooltip("The tag string to filter collisions.")]
    [SerializeField] private string filterTag = null; // The tag string to filter collisions.
    private AudioClip sfx = null;
    private AudioSource sfxSource;

    void Awake()
    {
        sfxSource = this.gameObject.GetComponent<AudioSource>();
        if (sfx != null && sfxSource != null) sfxSource.clip = sfx;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Do we have a filter tag...
        if (filterTag != "")
        {
            // ...and did we just collide with a game object with that tag...
            if (other.tag == filterTag)
            {
                // ...apply bounce.
                if (sfx != null && sfxSource != null) sfxSource.Play();
                BounceRigidbody(other.GetComponent<Rigidbody2D>());
                EnableTrail(other);
            }
        }
        else
        {
            // No filter, apply bounce.
            BounceRigidbody(other.GetComponent<Rigidbody2D>());
            EnableTrail(other);
        }
    }

    private void BounceRigidbody(Rigidbody2D rb)
    {
        // Add the bounce force to the other rigidbody.
        rb.AddForce(bounceForce);
    }

    private void EnableTrail(Collider2D other)
    {
        // Get the Trail Renderer component from the character.
        TrailRenderer trailRenderer = other.GetComponentInParent<TrailRenderer>();

        if (trailRenderer != null)
        {
            trailRenderer.enabled = true; // Enable the trail renderer.
            StartCoroutine(DisableTrailAfterDelay(trailRenderer));
        }
    }

    private IEnumerator DisableTrailAfterDelay(TrailRenderer trailRenderer)
    {
        // Wait for a short duration before disabling the trail renderer.
        yield return new WaitForSeconds(0.5f); // Adjust the time as needed.
        if (trailRenderer != null)
        {
            trailRenderer.enabled = false;
        }
    }
}
