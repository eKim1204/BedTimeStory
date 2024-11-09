using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyAI))]
public class Enemy : MonoBehaviour
{
    public EnemyAI enemyAI;
    public EnemyDataSO enemyData;

    public float maxHp;
    public float currHp;


    //===================================
    

    public void Init(int waveNum)
    {
        enemyAI = GetComponent<EnemyAI>();
        enemyAI.Init( enemyData, waveNum);

        maxHp = enemyData.maxHp * Mathf.Pow(1.5f,waveNum);
    }
}

