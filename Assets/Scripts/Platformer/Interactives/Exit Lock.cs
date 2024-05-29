using UnityEngine;

public class ExitLock : MonoBehaviour
{
    private GameObject pitcher; // Reference to the pitcher GameObject
    private GameObject newPitcher;
    private void Start()
    {
        pitcher = GameObject.Find("Pitcher");

        if (pitcher == null)
        {
            Destroy(gameObject);
        }
    }

    //private void Update()
    //{
    //    if (pitcher == null)
    //    {
    //        // Try to find the pitcher if not already found
    //        pitcher = GameObject.Find("Pitcher");
    //    }
    //
    //    

        // Check if the pitcher is still in the scene
    //    if (pitcher == null)
    //    {
    //        {
    //        Destroy(gameObject);
    //        }
    //    }
    //}
    void  DestroyWall() {
    Destroy(gameObject);
    }
}
