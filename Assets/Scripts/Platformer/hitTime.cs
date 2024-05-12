using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitTime : MonoBehaviour
{
    public float lifeTime;	// how long to live (seconds)


	void Start () 
	{
		Destroy (gameObject, lifeTime);
	}
}
