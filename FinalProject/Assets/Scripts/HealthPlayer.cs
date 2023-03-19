using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    //private HealthPlayer healthPlayer;
    public bool shield;
    public HealthBar healthBar;
   
    void Start()
    {
        shield = false;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    private void OnEnable()
    {
        EventManager.GetShieldEvent.AddListener(GetShield);
        EventManager.GetItemHealthEvent.AddListener(addHealth);
        
    }
    void GetShield()
    {
        shield=true;
        Debug.Log("shield");
    }
    
    void addHealth()
    {

        currentHealth += 10;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);

    }
    private void OnDisable()
    {
        EventManager.GetShieldEvent.RemoveListener(GetShield);
        EventManager.GetItemHealthEvent.RemoveListener(addHealth);
        
    }
    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDame(10);
        }*/
        fullHealth();


    }
    public void PlayerDamaged(int dame)
    {
        if (shield == true)
        {    
            shield=false;
            return;
        }
        currentHealth -= dame;
        healthBar.SetHealth(currentHealth);
        
        
    }
    public void fullHealth()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentHealth = 100;
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    GameObject whatHit = collision.gameObject;
    //    if (whatHit.CompareTag("health"))
    //    {
    //        addHealth(10);
    //        Destroy(whatHit);
    //    }
    //}
}
