using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHealth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
		GameObject whatHit = collision.gameObject;
		if (whatHit.CompareTag("Player"))
		{
			//Debug.Log("health");
			EventManager.GetItemHealthEvent.Invoke();
			Destroy(gameObject);
		}
	}
}
