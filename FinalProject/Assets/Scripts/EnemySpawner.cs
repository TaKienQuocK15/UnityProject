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

    private float existTime;

    // Start is called before the first frame update
    void Start()
    {
        existTime = Random.Range(15f, 30f);
        Invoke("DestroyPortal", existTime);

        StartCoroutine(spawnEnemy());
    }

    private IEnumerator spawnEnemy()
    {
        float interval = Random.Range(3f, 5f);
        yield return new WaitForSeconds(interval);
        float rand = Random.Range(1, 101);
        GameObject enemy;
        if (rand <= 50)
            enemy = zombiePrefab;
        else if (rand <= 90)
            enemy = doggoPrefab;
        else enemy = bossPrefab;

        if (GameManager.instance.currentMonsterNum < GameManager.instance.maxMonsterNum)
        {
			Instantiate(enemy, transform.position, Quaternion.identity);
            ++GameManager.instance.currentMonsterNum;
		}
        StartCoroutine(spawnEnemy());
    }

    private void DestroyPortal()
    {
        Destroy(gameObject);
        EventManager.PortalDestroyEvent.Invoke();
    }
}
