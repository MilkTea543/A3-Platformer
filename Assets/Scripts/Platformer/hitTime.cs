using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitTime : MonoBehaviour
{
    public float lifeTime;	// how long to live (seconds)
	private Rigidbody2D box;
	private SpriteRenderer boxRenderer;

	void Start () 
	{
		Destroy (gameObject, lifeTime);
	}
}
