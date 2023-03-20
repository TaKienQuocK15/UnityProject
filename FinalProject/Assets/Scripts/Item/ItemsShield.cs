using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsShield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject whatHit = collision.gameObject;
        if (whatHit.CompareTag("Player"))
        {
            EventManager.GetShieldEvent.Invoke();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
