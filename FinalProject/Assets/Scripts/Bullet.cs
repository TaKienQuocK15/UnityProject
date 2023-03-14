using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float life;
    private void Awake()
    {
        Destroy(gameObject,life);
    }
}
