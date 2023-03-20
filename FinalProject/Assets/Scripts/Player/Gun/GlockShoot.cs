using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlockShoot : Gun
{
	public override void Initialize()
	{
        range = 8;
        cooldownTime = 0.5f;
        damage = 1;
	}

	public override void FireBullet()
    {
        if (isCooldown)
            return;

        GameObject bullet = ObjectPool.instance.GetObject("Bullet");
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        bullet.GetComponent<Bullet>().SetLife(range / speed);
		bullet.GetComponent<Bullet>().SetDamage(damage);

		bullet.SetActive(true);
		Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
		rigidbody.velocity = speed * transform.up;
		StartCoroutine(Cooldown());
    }
}
