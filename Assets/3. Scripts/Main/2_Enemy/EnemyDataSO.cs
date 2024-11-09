using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameUtil;

[CreateAssetMenu(fileName = "EnemyInitData", menuName = "SO/EnemyData", order = int.MaxValue)]
public class EnemyDataSO : ScriptableObject
{
    public float maxHp = 100;
    
    public float movementSpeed = 4;
    public float attackSpeed = 2;    
    public float attackRange = 1.5f;
    public float playerDectectionRange = 10;

    public float dmg = 10;


    public float inc_maxHp = 10;
    public float inc_movementSpeed = 0.3f;
    public float inc_dmg = 3;


    public void Attack(Enemy enemy, Vector3 targetPos)
    {
        // Vector3 dir = (targetPos - enemy.t.position).WithFloorHeight().normalized;
        float radius = 1;

        Collider[] hits = Physics.OverlapSphere(targetPos.WithFloorHeight(), radius, GameConstants.playerLayer | GameConstants.towerLayer);
        // Debug.Log(hits.Length);
        // 충돌된 오브젝트들에 대해 반복 실행
        for(int i=0;i<hits.Length;i++)
        {
            Collider hit = hits[0];

            // 적에게 피해를 입히는 로직
            Player player = hit.GetComponent<Player>();
            if (player != null)
            {
                // Debug.Log("으악");
                PlayerStats.Instance.TakeDamage(dmg);
                continue;   
            }
            
            Tower tower = hit.GetComponent<Tower>();
            if (tower !=null)
            {
                // Debug.Log("타워워어");
                Debug.Log( dmg);
                tower.GetDamaged(dmg);
            }
        }
    }
    
}
