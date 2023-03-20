using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    internal int bulletNum;
    internal float range;
    internal bool isCooldown = false;
    internal float cooldownTime;
    internal float speed = 10;
    internal int damage;

    public abstract void Initialize();
    public abstract void FireBullet();

    internal IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
    }
}
