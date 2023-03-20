using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    [SerializeField] List<string> keyList;
    [SerializeField] List<GameObject> valueList;

    Dictionary<string, GameObject> prefabList;
    Dictionary<string, List<GameObject>> poolList;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(this);
    }

    private void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        prefabList = new Dictionary<string, GameObject>();
        for (int i = 0; i < keyList.Count; i++)
        {
            prefabList.Add(keyList[i], valueList[i]);
        }
        
        poolList = new Dictionary<string, List<GameObject>>();
        foreach (var pair in prefabList)
		{
            List<GameObject> pool = new List<GameObject>();
			for (int i = 0; i < 100; ++i)
			{
                GetNewObject(pair.Key);
			}
			poolList.Add(pair.Key, pool);
            
		}
	}

    GameObject GetNewObject(string key)
    {
        GameObject obj = Instantiate(prefabList[key]);
        obj.SetActive(false);
        return obj;
    }

    public GameObject GetObject(string key)
    {
        List<GameObject> pool = poolList[key];

		if (pool.Count > 0)
		{
			GameObject obj = pool[pool.Count - 1];
			pool.RemoveAt(pool.Count - 1);
			return obj;
		}
		else
		{
			pool.Capacity++;
			return GetNewObject(key);
		}
	}

    public void ReturnObject(string key, GameObject obj)
    {
		List<GameObject> pool = poolList[key];
        pool.Add(obj);
        obj.SetActive(false);
	}
}
