using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float maxHP = 100;
    private float currHP;
    private int currGold = 0;

    private void Awake()
    {
        currHP = maxHP;
    }

    void TakeDamage(float amount)
    {
        currHP = Mathf.Clamp(currHP - amount, 0, maxHP);
    }

    void Recover(float amount)
    {
        currHP = Mathf.Clamp(currHP + amount, 0, maxHP);
    }

    void GetGold(int amount)
    {
        currGold += amount;
    }
}
