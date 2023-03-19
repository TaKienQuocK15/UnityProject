using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject zombiePrefab;
    [SerializeField]
    private GameObject doggoPrefab;
    [SerializeField]
    private GameObject bossPrefab;
    [SerializeField]
    private float zombieCooldown = 2f;
    [SerializeField]
    private float doggoCooldown = 5.5f;
    [SerializeField]
    private float bossCooldown = 6.5f;
    public float spawnRange = 5f;
    // Start is called before the first frame update
    void Start()
    {

        /*StartCoroutine(spawnEnemy(doggoCooldown, doggoPrefab));
        StartCoroutine(spawnEnemy(bossCooldown, bossPrefab));*/
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(spawnEnemy(zombieCooldown, playerTransform));



    }
    private IEnumerator spawnEnemy(float interval, Transform playerTransform)
    {
        yield return new WaitForSeconds(interval);
        Vector3 randomOffset = transform.position + Random.insideUnitSphere * spawnRange;
        Vector3 spawnPos = playerTransform.position + randomOffset;
        /*GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);*/
        GameObject newEnemy = EnemyPool.instance.getEnemy();
        newEnemy.transform.position = spawnPos;
        newEnemy.SetActive(true);
        StartCoroutine(spawnEnemy(interval, playerTransform));
    }
}
