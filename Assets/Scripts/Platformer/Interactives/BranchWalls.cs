using UnityEngine;

public class DestroyOnShift : MonoBehaviour
{
    public float destroyDistance = 0.1f;  // The distance at which the object is destroyed
    public KeyCode destroyKey = KeyCode.LeftShift;  // The key used to trigger destruction

    void Update()
    {
        // Check if the player is pressing the destroy key
        if (Input.GetKeyDown(destroyKey))
        {
            // Get the distance between the player and the object
            float distance = Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);

            // Check if the player is within the destroy distance
            if (distance <= destroyDistance)
            {
                // Destroy the object
                Destroy(gameObject);
            }
        }
    }
}
