using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;  // Reference to the game over UI GameObject

    public void RestartGame()
    {
        int previousSceneIndex = PlayerPrefs.GetInt("PreviousSceneIndex", 0);
        SceneManager.LoadScene(previousSceneIndex);

        // Hide the game over UI
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }
    }
}
