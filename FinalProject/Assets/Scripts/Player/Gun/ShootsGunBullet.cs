using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootsGunBullet : Gun
{
    [SerializeField]
    private float spread;

	public override void Initialize()
	{
		range = 5;
		cooldownTime = 1f;
		bulletNum = 20;
		damage = 3;

		UIManager.instance.ChangeBulletNum(bulletNum);
	}
	
	public override void FireBullet()
    {
		if (isCooldown)
			return;

		float a = -spread;
        for(int i = 0; i < 3; i++)
        {
			GameObject bullet = ObjectPool.instance.GetObject("Bullet");
			bullet.transform.position = transform.position;
			bullet.transform.rotation = transform.rotation;
			bullet.GetComponent<Bullet>().SetLife(range / speed);
			bullet.GetComponent<Bullet>().SetDamage(damage);

			bullet.SetActive(true);
			Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
            Vector2 dir = transform.rotation * Vector2.up;
            Vector2 pdir = Vector2.Perpendicular(dir)*a;    
            rigidbody.velocity = (dir+pdir)*speed;
            a= a+spread;
        }

		bulletNum--;
		UIManager.instance.ChangeBulletNum(bulletNum);
		if (bulletNum <= 0)
			EventManager.GetGlock.Invoke();

		StartCoroutine(Cooldown());
        
    }
    
}
