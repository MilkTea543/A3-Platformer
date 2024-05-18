using UnityEngine;
using System.Collections;

public class FlickerOnDeath : MonoBehaviour
{
    public float flickerDuration = 1f; // Total duration of the flicker effect
    public float flickerInterval = 0.1f; // Time between each flicker
    public Color flickerColor = Color.red; // Color to flicker


    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool isFlickering = false;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void Die()
    {
        if (!isFlickering)
        {
            StartCoroutine(FlickerEffect());
        }
    }

    private IEnumerator FlickerEffect()
    {
        isFlickering = true;
        float elapsedTime = 0f;

        while (elapsedTime < flickerDuration)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            spriteRenderer.color = flickerColor;
            yield return new WaitForSeconds(flickerInterval);
            elapsedTime += flickerInterval;
        }

        spriteRenderer.enabled = true; // Ensure sprite is visible at the end
        Destroy(gameObject); // Destroy the enemy object
    }
}