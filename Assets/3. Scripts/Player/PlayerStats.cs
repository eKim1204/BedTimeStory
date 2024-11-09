using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : Singleton<PlayerStats>
{
    public enum Status
    {
        Idle,       //정지상태
        Walk,       //걷는상태
        Run,        //달리기 상태 (걷는상태 -> 달리기 상태 파생)
        Aim,        //에임상태 (에임상태->공격 상태 파생)
        Attack,     //공격상태
        Hitted,     //피격상태
        Dead,       //사망 -> 게임끝
    }
    public Status playerStatus { get; set; }
    private float maxHP = 100;
    private float currHP;
    private int currGold = 100000;
    public int CurrGold => currGold;

    private float attackPower;
    private float moveSpeed;
    private float reloadSpeed = 1;
    private float skillCooltime;

    public float AttackPower => attackPower;
    public float MoveSpeed => moveSpeed;
    public float ReloadSpeed => reloadSpeed;
    public float SkillCooltime => skillCooltime;

    public UnityEvent onGoldChanged;

    private void Awake()
    {
        playerStatus = Status.Idle;
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

        onGoldChanged.Invoke();
    }

    public void UseGold(int amount)
    {
        if (currGold >= amount)
            currGold -= amount;
        else
            throw new System.Exception("invalid use of gold!");

        onGoldChanged.Invoke();

        //Debug.Log("Currgold : " + currGold);
    }

    public void SetAttackPower(float value)
    {
        attackPower = value;
    }

    public void SetMoveSpeed(float value)
    {
        moveSpeed = value;
    }
    public void SetReloadSpeed(float value)
    {
        reloadSpeed = value;
    }
    public void SetSkillCooltime(float value)
    {
        skillCooltime = value;
    }

    public override void Init()
    {
        throw new System.NotImplementedException();
    }
}
