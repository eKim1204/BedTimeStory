using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem_Pouch : DropItem
{

    public override void Get()
    {
        PlayerStats.Instance.Recover(30);
    }

}
