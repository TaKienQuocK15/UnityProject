using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public  class EventManager :MonoBehaviour
{
    public static UnityEvent GetShieldEvent =new UnityEvent();
    public static UnityEvent GetItemHealthEvent =new UnityEvent();

}
