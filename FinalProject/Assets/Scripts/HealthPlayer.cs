using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

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
        currentHealth+=health;
        healthBar.SetHealth(currentHealth);
    }
}
