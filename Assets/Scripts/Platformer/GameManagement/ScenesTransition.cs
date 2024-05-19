using UnityEngine;
using System.Collections.Generic;

public class SceneTransition : MonoBehaviour
{
    [Tooltip("List of ingredients required for this level.")]
    public List<GameObject> levelIngredients;

    void Start()
    {
        // Set the required ingredients for this level
        IngredientManager.Instance.SetRequiredIngredients(levelIngredients);
    }
}
