using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 newPosi = transform.position;
            newPosi.x = player.transform.position.x;
            newPosi.y = player.transform.position.y;
            transform.position = newPosi;
        }
    }
}
