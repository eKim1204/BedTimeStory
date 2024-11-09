using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class Tower : DestroyableSingleton<Tower>
{


    public float hp;
    public float maxHp = 1000;


    public void Init()
    {
        hp = maxHp;
    }


    public void GetDamaged(float dmg)
    {
        hp -= dmg;

        GameEventManager.Instance.onChange_towerHp.Invoke();

        if (hp<= 0)
        {
            DestroyTower();
        }



    }


    public void DestroyTower()
    {
        // Destroy(gameObject);

        Debug.LogError("패배!!!!!!!!!!");
    }   

}
