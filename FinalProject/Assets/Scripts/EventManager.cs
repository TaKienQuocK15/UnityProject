using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public  class EventManager :MonoBehaviour
{
    public static UnityEvent GetShieldEvent =new UnityEvent();
    public static UnityEvent GetItemHealthEvent =new UnityEvent();
    public static UnityEvent enemyDieEvent = new UnityEvent();
    public static UnityEvent GetGlock = new UnityEvent();
    public static UnityEvent GetShootsGun = new UnityEvent();
    public static UnityEvent GetGetGatling = new UnityEvent();
    public static UnityEvent PortalDestroyEvent = new UnityEvent();
}
