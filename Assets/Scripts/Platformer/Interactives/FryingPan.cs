using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingPan : MonoBehaviour
{
    public Transform hitbox;
    public KeyCode useKey = KeyCode.LeftShift;  // The key used to trigger destruction
    public Vector3 attackRange;
    private bool killEnabled = false;


    // Start is called before the first frame update
    void Start()
    {

    }
    public void AddFryingPan()
    {
        killEnabled = true;
        Debug.Log("work");
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(useKey) & (killEnabled) & transform.localScale.x >= 1)
        {
            Debug.Log("hurt");
            Instantiate(hitbox, transform.position + attackRange, transform.rotation);
        }
        if (Input.GetKeyDown(useKey) & (killEnabled) & transform.localScale.x <= 1)
        {
            Debug.Log("hurt");
            Instantiate(hitbox, transform.position - attackRange, transform.rotation);
        }
    }
}