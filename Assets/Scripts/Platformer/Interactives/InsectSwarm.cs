using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectSwarm : MonoBehaviour
{   
    public float moveSpeed;
    public float timeActive;
    private GameObject target;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 direction = target.transform.position - transform.position;
            direction.Normalize();
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
        if (timeActive > 0) {
            timeActive -= Time.deltaTime;
            return;
        } 
        Destroy(gameObject);
    }
}
