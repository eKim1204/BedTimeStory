using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

using GameUtil;


[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    Transform t;
    Transform t_tower;
    Transform t_player;
    
    [SerializeField] Transform target;
    
    
    NavMeshAgent navAgent;
    
    Enemy enemy;

    public float playerDetectionRange = 10;
    public float attackRange = 1.5f;




    //=================================

    public void OnUpdate()
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

        //
        if( enemy.isCasting )
        {
            return;
        }


        // 아직 잘 되는 지는 모르겠음.
        float targetDistSqr =  t.position.WithFloorHeight().GetSqrDistWith(target.position.WithFloorHeight());
        

        if ( targetDistSqr <= attackRange * attackRange)   // 공격사거리 안 일때,
        {
            OnTargetInAttackRange();
        }
        else
        {
            OnTargetOutofAttackRange();
        }
    }



    public void Init(Enemy enemy, int waveNum)
    {
        this.enemy = enemy;
        
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.autoBraking = false;
        

        t=transform;
        t_tower = Tower.Instance.transform;
        t_player = Player.Instance.transform;


        //
        attackRange = enemy.enemyData.attackRange;
        playerDetectionRange = enemy.enemyData.playerDectectionRange;

        navAgent.speed = enemy.movementSpeed;
        // navAgent.stoppingDistance = attackRange;
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

    void OnTargetInAttackRange( )
    {
        if( enemy.attackAvailable )
        {
            enemy.Attack( target.position);
        }
        
        navAgent.isStopped = true;
        navAgent.velocity = Vector3.zero;

        
    }


    void OnTargetOutofAttackRange()
    {
        navAgent.isStopped = false;
    }


    //================================
    
    public void OnStopped()
    {
        navAgent.isStopped = true;
        navAgent.velocity = Vector3.zero;
    }

    public void OnDie()
    {
        navAgent.isStopped = true;
        navAgent.velocity = Vector3.zero;
    }

    //==================================
}
