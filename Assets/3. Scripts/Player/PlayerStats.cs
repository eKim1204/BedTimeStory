using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : Singleton<PlayerStats>
{
    public enum Status
    {
        Idle,       //��������
        Walk,       //�ȴ»���
        Run,        //�޸��� ���� (�ȴ»��� -> �޸��� ���� �Ļ�)
        Aim,        //���ӻ��� (���ӻ���->���� ���� �Ļ�)
        Attack,     //���ݻ���
        Hitted,     //�ǰݻ���
        Dead,       //��� -> ���ӳ�
    }
    public Status playerStatus { get; set; }
    private float maxHP = 100;
    private float currHP;
    private int currGold = 100000;
    public int CurrGold => currGold;

    private float attackPower;
    private float moveSpeed;
    private float reloadSpeed;
    private float skillCooltime;

    public float AttackPower => attackPower;
    public float MoveSpeed => moveSpeed;
    public float ReloadSpeed => reloadSpeed;
    public float SkillCooltime => skillCooltime;

    public UnityEvent onGoldChanged;

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

        onGoldChanged.Invoke();
    }

    public void UseGold(int amount)
    {
        if (currGold >= amount)
            currGold -= amount;
        else
            throw new System.Exception("invalid use of gold!");

        onGoldChanged.Invoke();

        Debug.Log("Currgold : " + currGold);
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
