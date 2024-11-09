using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Singleton<PlayerStats>
{
    private float maxHP = 100;
    private float currHP;
    private int currGold = 0;

    private void Awake()
    {
        currHP = maxHP;
    }

    public void TakeDamage(float amount)
    {
        currHP = Mathf.Clamp(currHP - amount, 0, maxHP);
    }

    public void Recover(float amount)
    {
        currHP = Mathf.Clamp(currHP + amount, 0, maxHP);
    }

    public void GetGold(int amount)
    {
        currGold += amount;
    }

    public void UseGold(int amount)
    {
        if (currGold >= amount)
            currGold -= amount;
        else
            Debug.Log("∞ÒµÂ ∫Œ¡∑");
    }

    public override void Init()
    {
        throw new System.NotImplementedException();
    }
}
