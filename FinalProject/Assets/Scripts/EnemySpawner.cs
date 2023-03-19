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
    private float zombieCooldown = 3.5f;
    [SerializeField]
    private float doggoCooldown = 5.5f;
    [SerializeField]
    private float bossCooldown = 6.5f;

    private float existTime;

    // Start is called before the first frame update
    void Start()
    {
        existTime = Random.Range(15f, 30f);
        Invoke("DestroyPortal", existTime);

        //StartCoroutine(spawnEnemy(zombieCooldown, zombiePrefab));
        //StartCoroutine(spawnEnemy(doggoCooldown, doggoPrefab));
        //StartCoroutine(spawnEnemy(bossCooldown, bossPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, newEnemy));
    }

    private void DestroyPortal()
    {
        Destroy(gameObject);
        EventManager.PortalDestroyEvent.Invoke();
    }
}
