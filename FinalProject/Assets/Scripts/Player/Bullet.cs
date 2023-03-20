using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float life;
    private float damage;

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

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public void DestroyBullet()
    {
        ObjectPool.instance.ReturnObject("Bullet", gameObject);
    }
}
