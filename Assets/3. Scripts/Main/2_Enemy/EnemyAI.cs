using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using GameUtil;
using UnityEditor.Experimental.GraphView;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    Transform t;
    Transform t_tower;
    Transform t_player;
    
    Transform target;
    
    
    NavMeshAgent navAgent;
    
    public float playerDetectionRange = 10;
    public float attackRange = 1.5f;

    void Update()
    {
        // 플레이어 쫓는 경우
        if (t.position.GetSqrDistWith(t_player.position) <= playerDetectionRange * playerDetectionRange )
        {   
            OnPlayerInRange();
        }
        // 타워 쫓는경우
        else
        {
            OnPlayerOutOfRange();
        }



        // 아직 잘 되는 지는 모르겠음.
        if ( t.position.GetSqrDistWith(target.position) <= attackRange)
        {
            OnTargetInAttackRange();
        }
        else
        {
            OnTargetOutofAttackRange();
        }
    }



    public void Init(EnemyDataSO enemyData, int waveNum)
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.autoBraking = false;


        t=transform;
        t_tower = Tower.Instance.transform;
        t_player = Player.Instance.transform;


        //
        navAgent.speed = enemyData.movementSpeed;
        attackRange = enemyData.attackRange;
        playerDetectionRange = enemyData.playerDectectionRange;
    }


    void OnPlayerInRange()
    {
        target = t_player;
        navAgent.SetDestination( target.position );   // 플레이어 쫓음
    }

    void OnPlayerOutOfRange()
    {
        target = t_tower;
        navAgent.SetDestination( target.position );    // 타워 쫓음
    }

    void OnTargetInAttackRange()
    {
        navAgent.isStopped = true;
    }


    void OnTargetOutofAttackRange()
    {
        navAgent.isStopped = false;
    }
}
