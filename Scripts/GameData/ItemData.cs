using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemData : ScriptableObject
{
    // This will be available on next version so I hide this now.
    [HideInInspector]
    public int price;
    public static bool IsUnlock(ItemData item)
    {
        return item.price == 0;
    }
}
