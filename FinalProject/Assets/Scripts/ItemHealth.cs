using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHealth : MonoBehaviour
{
   

    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject whatHit = collision.gameObject;
        if (whatHit.CompareTag("Player"))
        {
            //Debug.Log("health");
            EventManager.GetItemHealthEvent.Invoke();
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }
}
