using UnityEngine;
using System.Collections;

public class detectHit : MonoBehaviour 
{

	private void OnCollisionEnter2D(Collision2D c)
	{
		c.gameObject.SendMessage("panHit"); 
	}
}