using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 5;
    [SerializeField]
    private float speed = 1.5f;
    [SerializeField]
    private float hp = 5;
    [SerializeField]
    private EnemyData Data;
    private GameObject player;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        hp = Data.hp;
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
        /*TouchPlayer();*/
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
    private void damagePlayer()
    {

    }
    private void damaged(int amount)
    {
        hp -= amount;
        if(hp <= 0)
        {
            Destroy(gameObject);
        }

    }
    /*private void TouchPlayer()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, enemyLayer);
        foreach (Collider2D hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Player"))
            {
                damaged(5);
            }
        }
        
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("trigger");
    }
}
