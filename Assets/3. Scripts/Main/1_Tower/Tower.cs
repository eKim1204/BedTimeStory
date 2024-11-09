using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : DestroyableSingleton<Tower>
{


    public int hp;
    public int maxHp = 1000;


    public void Init()
    {
        hp = maxHp;
    }

}
