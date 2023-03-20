using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float life;
    private int damage;

    private void OnEnable()
    { 
        Invoke("DestroyBullet", life);
	}

    private void OnDisable()
    {
        CancelInvoke();
    }

    public void SetLife(float life)
    {
        this.life = life;
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public int GetDamage()
    {
        return damage;
    }

    public void DestroyBullet()
    {
        ObjectPool.instance.ReturnObject("Bullet", gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
            DestroyBullet();
    }
}
