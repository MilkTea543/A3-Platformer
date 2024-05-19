using UnityEngine;
using System.Collections.Generic;

public class IngredientManager : MonoBehaviour
{
    public static IngredientManager Instance { get; private set; }

    private HashSet<GameObject> collectedIngredients = new HashSet<GameObject>();
    private List<GameObject> requiredIngredients = new List<GameObject>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void CollectIngredient(GameObject ingredient)
    {
        collectedIngredients.Add(ingredient);
    }

    public void SetRequiredIngredients(List<GameObject> ingredients)
    {
        requiredIngredients = ingredients;
    }

    public bool HasCollectedAllIngredients()
    {
        return requiredIngredients.TrueForAll(ingredient => collectedIngredients.Contains(ingredient));
    }
}
