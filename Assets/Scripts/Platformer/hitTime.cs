using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitTime : MonoBehaviour
{
    public float lifeTime;	// how long to live (seconds)
	private Rigidbody2D box;
	private SpriteRenderer boxRenderer;
	private AudioClip sfx = null;	
	private AudioSource sfxSource;
	
	void Awake ()
	{
	    sfxSource = this.gameObject.GetComponent<AudioSource>();
		if (sfx != null && sfxSource != null) sfxSource.clip = sfx;	
	}
	void Start () 
	{
		if (sfx != null && sfxSource != null) sfxSource.Play();
		Destroy (gameObject, lifeTime);
	}
}
