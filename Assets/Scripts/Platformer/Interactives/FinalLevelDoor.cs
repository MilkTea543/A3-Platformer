using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLevelDoor : MonoBehaviour
{
    public string succeedSceneName; // Name of the level complete scene

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && IngredientManager.Instance.HasCollectedAllIngredients())
        {
            LoadSucceedScene();
        }
        else
        {
            Debug.Log("Not all ingredients collected.");
        }
    }

    private void LoadSucceedScene()
    {
        SceneManager.LoadScene(succeedSceneName);
    }
}
