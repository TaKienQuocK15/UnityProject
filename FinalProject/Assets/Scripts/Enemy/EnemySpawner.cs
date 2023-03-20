using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float existTime;

    // Start is called before the first frame update
    void Start()
    {
        existTime = Random.Range(15f, 30f);
        Invoke("DestroyPortal", existTime);

        //StartCoroutine(spawnEnemy());
    }

    private IEnumerator spawnEnemy()
    {
        float interval = Random.Range(3f, 5f);
        yield return new WaitForSeconds(interval);
        float rand = Random.Range(1, 101);
        GameObject enemy;
        if (rand <= 50)
            enemy = ObjectPool.instance.GetObject("Zombie");
        else if (rand <= 90)
            enemy = ObjectPool.instance.GetObject("Doggo");
        else enemy = ObjectPool.instance.GetObject("Boss");


		if (!GameManager.instance.FullEnemy())
        {
            enemy.transform.position = transform.position;
            enemy.SetActive(true);
            EventManager.EnemySpawnEvent.Invoke();
		}
        StartCoroutine(spawnEnemy());
    }

    private void DestroyPortal()
    {
        Destroy(gameObject);
        EventManager.PortalDestroyEvent.Invoke();
    }
}
