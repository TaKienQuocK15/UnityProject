using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GatlingShoot : Gun
{
	public override void Initialize()
	{
		range = 7;
		cooldownTime = 0.2f;
		bulletNum = 100;
	}

	public override void FireBullet()
	{
		if (isCooldown)
			return;

		GameObject bullet = ObjectPool.instance.GetObject("Bullet");
		bullet.transform.position = transform.position;
		bullet.transform.rotation = transform.rotation;
		bullet.GetComponent<Bullet>().SetLife(range / speed);

		bullet.SetActive(true);
		Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
		rigidbody.velocity = speed * transform.up;
		StartCoroutine(Cooldown());
	}
}
