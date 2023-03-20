using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GatlingShoot : Gun
{
	public override void Initialize()
	{
		range = 8;
		cooldownTime = 0.2f;
		bulletNum = 100;
		damage = 1;

		UIManager.instance.ChangeBulletNum(bulletNum);
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

		bulletNum--;
		UIManager.instance.ChangeBulletNum(bulletNum);
		if (bulletNum <= 0)
			EventManager.GetGlock.Invoke();

		StartCoroutine(Cooldown());
	}
}
