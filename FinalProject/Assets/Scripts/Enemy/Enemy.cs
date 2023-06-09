using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
	[SerializeField]
	private EnemyData Data;

	private int damage;
    private float speed;
    private int hp;
    private int score;
    
    private GameObject player;
    private bool damaging = false;
    HealthPlayer playerHealth;

    GameObject[] items;
    [SerializeField] string poolKey;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        setEnemyValues();

        items = GameManager.instance.droppableItems;
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
    }
    
    private void followPlayer()
    {
        if(player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    private void setEnemyValues()
    {
        hp = Data.hp;
        damage = 1;
        speed = Data.speed;
        score = Data.score;
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
        EventManager.EnemyDestroyEvent.Invoke(new EnemyDestroyEventData
        {
            score = this.score
        });

        //Drop item
        int rand = Random.Range(1, 101);
        if (rand <= 30)
        {
            int itemId = Random.Range(0, items.Length);
            Instantiate(items[itemId], transform.position, Quaternion.identity);
        }
        
        ObjectPool.instance.ReturnObject(poolKey, gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            playerHealth = collision.gameObject.GetComponent<HealthPlayer>();
            if (playerHealth != null)
            {
				playerHealth.PlayerDamaged(damage);
			}
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            GameObject bullet = collision.gameObject;
            damaged(bullet.GetComponent<Bullet>().GetDamage());
            bullet.GetComponent<Bullet>().DestroyBullet();
        }
    }
}
