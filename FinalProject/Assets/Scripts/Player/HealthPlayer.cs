using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    //private HealthPlayer healthPlayer;
    public bool shield;
    [SerializeField] GameObject shieldIcon;
    public bool invincible;
    public HealthBar healthBar;
   
    void Start()
    {
        shield = false;
        invincible = false;
        maxHealth = 10;
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
        shield = true;
        shieldIcon.SetActive(true);
    }
    
    void addHealth()
    {

        currentHealth += 1;
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
    
    public void PlayerDamaged(int dame)
    {
        if (invincible)
            return;

        if (shield == true)
        {    
            shield=false;
            shieldIcon.SetActive(false);
            BeInvincible();
            return;
        }

        currentHealth -= dame;
        if (currentHealth <= 0)
        {
            EventManager.GameOverEvent.Invoke();
            return;
        }

        healthBar.SetHealth(currentHealth);
        BeInvincible();
    }

    void BeInvincible()
    {
        invincible = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(InvincibleCooldown());
    }

    IEnumerator InvincibleCooldown()
    {
        yield return new WaitForSeconds(3f);
        invincible = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
