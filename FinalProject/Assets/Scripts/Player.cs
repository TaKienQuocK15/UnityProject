using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public FixedJoystick joystick;
    public FixedJoystick aimjoystick;
    Rigidbody2D rb;
    Vector2 move;
    Vector2 aim;
    public float speed;
    int totalGun = 3;
    public int currentGun;
    public GameObject[] gun;
    public GameObject weapon;
    public GameObject currentweapons;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        totalGun = weapon.transform.childCount;
        gun = new GameObject[totalGun];
        for(int i = 0; i < totalGun; i++)
        {
            gun[i] = weapon.transform.GetChild(i).gameObject;
            gun[i].SetActive(false);
        }
        gun[0].SetActive(true);
        currentweapons = gun[0];
        currentGun = 0;
        Debug.Log(totalGun);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(currentGun < totalGun-1)
            {
                gun[currentGun].SetActive(false);
                currentGun++;
                gun[currentGun].SetActive(true) ;
                Debug.Log(currentGun);
            }else
            if(currentGun >0)
            {
                gun[currentGun].SetActive(false);
                currentGun--;
                gun[currentGun].SetActive(true);
                Debug.Log(currentGun);
            }
        }

        move.x = joystick.Horizontal;
        move.y = joystick.Vertical;

        aim = new Vector2(aimjoystick.Horizontal, aimjoystick.Vertical);
        float hAxis = aim.x;
        float vAxis = aim.y;
        float zAxis = Mathf.Atan2(hAxis, vAxis)*Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0f,0f,-zAxis);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position+move*speed*Time.fixedDeltaTime);
    }

}
