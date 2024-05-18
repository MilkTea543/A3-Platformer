using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // Add this directive for scene management

public class Health : MonoBehaviour
{
    // Inspector configuration
    [SerializeField] private float totalHealth = 100f;   // Total health points
    [SerializeField] private bool clampHealth = true;
    [SerializeField] private float pickupHealth = 25f;   // Health points gained from pickups
    [SerializeField] private float damage = 10f;
    [SerializeField] private float bulletDamage = 5f;
    [SerializeField] private float mineDamage = 20f;

    // The player's current health
    private float health = 0;
    private Text healthText;
    private GameObject player;

    void Awake()
    {
        healthText = GetComponent<Text>();
        health = totalHealth;
        healthText.text = "Health: " + (int)health;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void LoseAllHealth()
    {
        health = 0;
        CheckHealth();
        healthText.text = "Health: " + (int)health;
    }

    public void AddHealthPickup()
    {
        health += pickupHealth;
        if (clampHealth && health > totalHealth)
            health = totalHealth;
        healthText.text = "Health: " + (int)health;
    }

    public void SubtractHealthOverTime()
    {
        health -= damage * Time.fixedDeltaTime;
        CheckHealth();
        if (health < 0)
            health = 0;
        healthText.text = "Health: " + (int)health;
    }

    public void SubtractHealthOnHit()
    {
        health -= damage;
        CheckHealth();
        if (health < 0)
            health = 0;
        healthText.text = "Health: " + (int)health;
    }

    public void SubtractBulletHealthOnHit()
    {
        health -= bulletDamage;
        CheckHealth();
        if (health < 0)
            health = 0;
        healthText.text = "Health: " + (int)health;
    }

    public void SubtractMineDamage()
    {
        health -= mineDamage;
        CheckHealth();
        if (health < 0)
            health = 0;
        healthText.text = "Health: " + (int)health;
    }

    public void ResetHealth()
    {
        health = totalHealth;
        healthText.text = "Health: " + (int)health;
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        PlayerPrefs.SetInt("PreviousSceneIndex", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("PlatformerGameOver");
    }
}
