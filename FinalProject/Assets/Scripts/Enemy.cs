using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 10;
    [SerializeField]
    private float speed = 1.5f;
    [SerializeField]
    private float hp = 20;
    [SerializeField]
    private EnemyData Data;
    private GameObject player;
    private float distance;
    private bool damaging = false;
    HealthPlayer playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        setEnemyValues();
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
        /*TouchPlayer();*/
        
    }
    private void OnEnable()
    {
        EventManager.GetShieldEvent.AddListener(enemyDie);


    }
    private void OnDisable()
    {
        EventManager.GetShieldEvent.RemoveListener(enemyDie);
    }
    private void followPlayer()
    {
        if(player != null)
        {
            /*distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;*/
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Data.speed * Time.deltaTime);
        }
    }
    private void setEnemyValues()
    {
        hp = Data.hp;
        damage = Data.damage;
        speed = Data.speed;
    }
    private void damaged(int amount)
    {
        hp -= amount;
        if(hp <= 0)
        {
            enemyDie();
        }

    }
    private void enemyDie()
    {
        GetComponent<LootBag>().dropLoot(transform.position);
        EnemyPool.instance.returnEnemyToPool(gameObject);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            playerHealth = collision.gameObject.GetComponent<HealthPlayer>();
            if (playerHealth != null)
            {
                if(!damaging)
                StartCoroutine(dealingDamage());
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Bullet"))
        {
            damaged(50);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Stop taking damage when no longer colliding
            damaging = false;
        }
    }
    IEnumerator dealingDamage()
    {
        damaging = true;

        while (true)
        {

            // Inflict damage every second while still colliding
            playerHealth.PlayerDamaged(damage);

            yield return new WaitForSeconds(1);

            // Exit loop when no longer colliding
            if (!damaging)
                break;
        }
        damaging = false;
    }
}
