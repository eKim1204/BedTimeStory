using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem_Potion : DropItem
{
    public override void Get()
    {
        PlayerStats.Instance.GetGold(100);
    }


}
