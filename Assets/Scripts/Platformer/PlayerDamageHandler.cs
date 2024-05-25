using System;
using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour
{
    public GameObject damageEffectPrefab; // Reference to the particle system prefab
    private GameObject damageEffectInstance;

    private void Start()
    {
        // Instantiate the particle system and deactivate it initially
        if (damageEffectPrefab != null)
        {
            damageEffectInstance = Instantiate(damageEffectPrefab, transform.position, Quaternion.identity);
            damageEffectInstance.transform.SetParent(transform);
            damageEffectInstance.SetActive(false);
        }
    }

    public void TakeDamage()
    {
        // Activate the particle effect when the player takes damage
        if (damageEffectInstance != null)
        {
            damageEffectInstance.SetActive(true);
            ParticleSystem ps = damageEffectInstance.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();
            }

            // Deactivate the particle effect after it has played
            StartCoroutine(DeactivateEffect(ps.main.duration));
        }
    }

    private System.Collections.IEnumerator DeactivateEffect(float delay)
    {
        yield return new WaitForSeconds(delay);
        damageEffectInstance.SetActive(false);
    }
}
