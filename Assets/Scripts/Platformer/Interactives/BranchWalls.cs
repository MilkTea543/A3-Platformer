using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;
using System.Collections.Generic;

public class DestroyOnShift : MonoBehaviour
{
    public float destroyDistance = 0.1f;  // The distance at which the object is destroyed
    public KeyCode destroyKey = KeyCode.LeftShift;  // The key used to trigger destruction
    private bool destroyEnabled;

    public void panUnlocked()
    {
        destroyEnabled = true;
    }
    void Update()
    {
        // Check if the player is pressing the destroy key
        if (Input.GetKeyDown(destroyKey) & (destroyEnabled))
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
