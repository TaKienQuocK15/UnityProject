using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlockShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private float speed;
    public FixedJoystick aimjoystick;
    [SerializeField]
    private float countdow;
    private float lasttime;

    void Update()
    {
        float time = Time.time - lasttime;
        if (time >= countdow)
        {
            OnFire();
            lasttime = Time.time;
        }


    }
    private void FireBullet()
    {
        GameObject bullet = Instantiate(_bullet, transform.position, transform.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.velocity = speed * transform.up;
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
