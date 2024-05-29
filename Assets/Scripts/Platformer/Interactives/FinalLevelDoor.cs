using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLevelDoor : MonoBehaviour
{
    public string succeedSceneName; // Name of the level complete scene
    public string failSceneName;    // Name of the level fail scene

    private bool bossKilled = false;
    private GameObject boss;
    private Collider2D doorCollider;

    private void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
        if (boss == null)
        {
            Debug.LogError("Boss not found in the scene!");
        }

        doorCollider = GetComponent<Collider2D>();
        if (doorCollider == null)
        {
            Debug.LogError("Collider not found on the door GameObject!");
        }
    }

    private void Update()
    {
        if (boss == null && !bossKilled)
        {
            bossKilled = true;
            doorCollider.enabled = true; // Enable the collider when the boss is killed
        }
        else if (boss != null && bossKilled)
        {
            bossKilled = false;
            doorCollider.enabled = false; // Disable the collider when the boss is alive
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!bossKilled)
            {
                Debug.Log("Boss is still alive. Door is disabled.");
                return;
            }

            if (IngredientManager.Instance.HasCollectedAllIngredients())
            {
                LoadSucceedScene();
            }
            else
            {
                LoadFailScene();
            }
        }
    }

    private void LoadSucceedScene()
    {
        SceneManager.LoadScene(succeedSceneName);
    }

    private void LoadFailScene()
    {
        SceneManager.LoadScene(failSceneName);
    }
}
