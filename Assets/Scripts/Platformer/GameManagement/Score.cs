using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [Tooltip("Score prefix. Default is 'Collect: '")]
    [SerializeField] private string scorePrefix = "Collect: ";
    [Tooltip("Total number of pickups in the level")]
    [SerializeField] private int totalPickups = 8;
    [Tooltip("How many points is each pickup worth?")]
    [SerializeField] private int scoreForPickup = 1;

    private int score = 0;
    private Text scoreText;

    void Awake()
    {
        scoreText = GetComponent<Text>();
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = scorePrefix + score + "/" + totalPickups;
    }

    public void AddScoreOnPickup()
    {
        score += scoreForPickup;
        UpdateScoreText();
    }
}
