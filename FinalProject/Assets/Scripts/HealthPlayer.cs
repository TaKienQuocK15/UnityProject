using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    //private HealthPlayer healthPlayer;

    public HealthBar healthBar;
   
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDame(10);
        }
        
    }
    void TakeDame(int dame)
    {
        currentHealth -= dame;
        healthBar.SetHealth(currentHealth);
        
    }
   public void addHealth(int health)
    {
        currentHealth += health;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }      
        healthBar.SetHealth(currentHealth);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject whatHit = collision.gameObject;
        if (whatHit.CompareTag("health"))
        {
            addHealth(10);
            Destroy(whatHit);
        }
    }
}
