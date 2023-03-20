using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootsGunBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private float speed;
    public FixedJoystick aimjoystick;
    [SerializeField]
    private float countdow;
    private float lasttime;
    [SerializeField]
    private float spread;
    private int amount = 25;

    private void OnEnable()
    {
        amount = 25;
    }

    void Update()
    {
        float time = Time.time - lasttime;
        if (time >= countdow)
        {
            OnFire();
            lasttime = Time.time;
            amount--;
        }
        if (amount < 0)
        {
            //amount = 25;
            EventManager.GetGlock.Invoke();
        }


    }
    private void FireBullet()
    {
        float a = -spread;
        Debug.Log("fire");
        for(int i =0; i < 3; i++)
        {
            GameObject bullet = Instantiate(_bullet, transform.position, transform.rotation);
            Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
            Vector2 dir = transform.rotation * Vector2.up;
            Vector2 pdir = Vector2.Perpendicular(dir)*a;    
            rigidbody.velocity = (dir+pdir)*speed;
            a= a+spread;
            
        }
        
    }
    private void OnFire()
    {
        if (aimjoystick.Horizontal >= 0.6f || aimjoystick.Vertical >= 0.6f)
        {
            FireBullet();
        }
        else if (aimjoystick.Horizontal <= -0.6f || aimjoystick.Vertical <= -0.6f)
        {
            FireBullet();
        }
    }
}
