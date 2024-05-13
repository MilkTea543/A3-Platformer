using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [Tooltip("Score prefix. Default is 'Collect: '")]
    [SerializeField] private string scorePrefix = "Collect: ";    // The score prefix.
    [Tooltip("Total number of pickups in the level")]
    [SerializeField] private int totalPickups = 8;                // Total number of pickups in the level.
    [Tooltip("How many points is each pickup worth?")]
    [SerializeField] private int scoreForPickup = 1;             // How many points does each pickup get me.

    private int score = 0;      // The player's current score

    private Text scoreText;     // Reference to the Text component.

    void Awake()
    {
        // Get the reference to the Text component.
        scoreText = GetComponent<Text>();
        // Set the initial score text.
        UpdateScoreText();
    }

    // Update the score text with the current score and total pickups
    private void UpdateScoreText()
    {
        scoreText.text = scorePrefix + score + "/" + totalPickups;
    }

    // collected a certain kind of pickup -- add score
    public void AddScoreOnPickup()
    {
        score += scoreForPickup;
        UpdateScoreText();
    }

    // killed a certain kind of enemy -- add score
    public void AddScoreForEnemyKill(int enemyScore)
    {
        score += enemyScore;
        UpdateScoreText();
    }
}
