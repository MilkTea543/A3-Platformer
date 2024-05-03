using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweetrap : MonoBehaviour
{   
    public Transform instantiateObject;
    public float spawnTime;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) {
            timer -= Time.deltaTime;
            return;
        } 
        Instantiate (instantiateObject, transform.position, transform.rotation);
        timer = spawnTime;
    }
}
