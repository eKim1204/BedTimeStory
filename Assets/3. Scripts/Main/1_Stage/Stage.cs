using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : DestroyableSingleton<Stage>
{
    [SerializeField] Transform t_playerSpawnPoint;
    
    public Vector3 playerInitPos => t_playerSpawnPoint.position;
    
    [SerializeField] Transform t_enemySpawnAreaParent;
    [SerializeField] BoxCollider[] enemySpawnArea;


    //

    public void Init()
    {
        enemySpawnArea = t_enemySpawnAreaParent.GetComponentsInChildren<BoxCollider>();
    }



    /// <summary>
    /// 해당 영역에서 임의의 좌표를 얻는다. 
    /// </summary>
    /// <returns></returns>
    public Vector3 GetRandomSpawnPoint()
    {
        Vector3 ret = Vector3.zero;

        if (enemySpawnArea.Length>0)
        {
            int randIdx = Random.Range(0,enemySpawnArea.Length);
            BoxCollider area = enemySpawnArea[randIdx];

            Bounds bounds = area.bounds;

            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomZ = Random.Range(bounds.min.z, bounds.max.z);

            ret = new Vector3(randomX, 0, randomZ);
        }

        return ret;
    }

}
