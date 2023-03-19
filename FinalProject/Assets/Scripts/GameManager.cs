using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    int maxPortalNum = 5;
    public int maxMonsterNum = 100;
    public int currentMonsterNum;

    public GameObject[] droppableItems;
    
    [SerializeField] Transform pointNW, pointSE;
    [SerializeField] GameObject portalPrefab;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(this);
    }

    private void OnEnable()
    {
        EventManager.PortalDestroyEvent.AddListener(SpawnPortal);
    }

    private void OnDisable()
    {
        EventManager.PortalDestroyEvent.RemoveListener(SpawnPortal);
    }

    private void Start()
    {
        for (int i = 0; i < maxPortalNum; i++)
        {
            SpawnPortal();
        }

        currentMonsterNum = 0;
    }

    void SpawnPortal()
    {
		Instantiate(portalPrefab, GetRandomPortalLocation(), Quaternion.identity);
	}
    
    Vector2 GetRandomPortalLocation()
    {
        float x = Random.Range(pointNW.position.x, pointSE.position.x);
        float y = Random.Range(pointSE.position.y, pointNW.position.y);

        return new Vector2(x, y);
    }
}
