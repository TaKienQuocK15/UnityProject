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

    [SerializeField] Gun glockGun;
    [SerializeField] Gun gatlingGun;
    [SerializeField] Gun shotGun;
    Gun currentGun;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ChangeToDefaultGun();
    }

    private void Update()
    {
        move.x = joystick.Horizontal;
        move.y = joystick.Vertical;

        aim = new Vector2(aimjoystick.Horizontal, aimjoystick.Vertical);
        float hAxis = aim.x;
        float vAxis = aim.y;
        float zAxis = Mathf.Atan2(hAxis, vAxis)*Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0f,0f,-zAxis);

		if (aimjoystick.Horizontal >= 0.6f || aimjoystick.Vertical >= 0.6f)
        {
            FireBullet();
        }
        else if (aimjoystick.Horizontal <= -0.6f || aimjoystick.Vertical <= -0.6f)
        {
            FireBullet();
        }
    }

	private void OnEnable()
    {
        EventManager.GetGlock.AddListener(changeGlock);
        EventManager.GetShootsGun.AddListener(changeShootgun);
        EventManager.GetGetGatling.AddListener(changeGatling);
    }

    private void OnDisable()
    {
        EventManager.GetGlock.RemoveListener(changeGlock);
        EventManager.GetShootsGun.RemoveListener(changeShootgun);
        EventManager.GetGetGatling.RemoveListener(changeGatling);
    }

    void changeGun(Gun gun)
    {
        currentGun = gun;
        currentGun.Initialize();
    }

    void changeGlock()
    {
        changeGun(glockGun);
    }

    void changeShootgun()
    {
        changeGun(shotGun);
    }

    void changeGatling()
    {
        changeGun(gatlingGun);
    }

    void ChangeToDefaultGun()
    {
        changeGlock();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position+move*speed*Time.fixedDeltaTime);
    }

    private void FireBullet()
    {
        currentGun.FireBullet();
    }

}
