using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private float speed;
    public FixedJoystick aimjoystick;
    [SerializeField]
    private float countdow;
    private float lasttime;
    // Start is called before the first frame update

    // Update is called once per frame
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
        GameObject bullet = Instantiate(_bullet, transform.position,transform.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.velocity = speed*transform.up;
    }
    private void OnFire()
    {
        if (aimjoystick.Horizontal >= 0.6f || aimjoystick.Vertical >= 0.6f)
        {
            FireBullet();
        }else if (aimjoystick.Horizontal <= -0.6f || aimjoystick.Vertical <= -0.6f)
        {
            FireBullet();
        }
    }
}
