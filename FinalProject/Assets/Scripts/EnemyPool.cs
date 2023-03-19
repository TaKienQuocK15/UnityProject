using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    static public EnemyPool instance;
    [SerializeField] GameObject enemyPrefab;
    List<GameObject> enemyPool;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        Initialize();
    }
    void Initialize()
    {
        enemyPool = new List<GameObject>(10);
        for (int i = 0; i < enemyPool.Capacity; ++i)
        {
            enemyPool.Add(getNewEnemy());
        }
    }
    GameObject getNewEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.SetActive(false);
        return enemy;
    }
    public GameObject getEnemy()
    {
        if (enemyPool.Count > 0)
        {
            GameObject enemy = enemyPool[enemyPool.Count - 1];
            enemyPool.RemoveAt(enemyPool.Count - 1);
            return enemy;
        }
        else
        {
            enemyPool.Capacity++;
            return getNewEnemy();
        }
    }
    public void returnEnemyToPool(GameObject enemy)
    {
        enemyPool.Add(enemy);
        enemy.SetActive(false);
    }
}
