using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyInitData", menuName = "SO/EnemyData", order = int.MaxValue)]
public class EnemyDataSO : ScriptableObject
{
    public float maxHp = 100;
    public float movementSpeed = 4;
    public float attackSpeed = 2;    
    public float attackRange = 1.5f;
    public float playerDectectionRange = 10;

    public float dmg = 10;
    
}
