using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int hp;
    public int maxHp = 1000;

    void Start()
    {
        Init();
    }


    public void Init()
    {
        hp = maxHp;
    }

}
