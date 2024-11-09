using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class WaveManager : DestroyableSingleton<WaveManager>
{
    
    
    
    
    public GameObject prefab_enemy;

    public StageWaveInfoSO stageWaveInfo;

    public int clearedWaveNum;

    public int currWaveNum => clearedWaveNum +1;
    
    public bool waveFinished {get;private set;}

    public bool isWavePlaying; 
    public float wavePlayTime;


    //=======================================================================================================

    void Update()
    {
        if (isWavePlaying)
        {
            wavePlayTime += Time.deltaTime;
        }
    }


    public void StartWave()
    {
        
        wavePlayTime = 0;

        WaveInfo waveInfo  = stageWaveInfo.waveInfos[clearedWaveNum];
        
        float waveDuration = waveInfo.duration;
        int spawnPerSeconds = waveInfo.spawnPerSeconds;

        IncreaseDifficulty();
        StartCoroutine( DurationRoutine (waveDuration));
        StartCoroutine( SpawnRoutine (spawnPerSeconds));

    }  
    

    /// <summary>
    /// 현재 웨이브에 맞춰 난이도를 높인다. 
    /// </summary>
    public void IncreaseDifficulty()
    {
        //적 체력 향상
        
    }


    /// <summary>
    /// 웨이브 지속시간 끝나는거 감지
    /// </summary>
    /// <param name="waveDuration"></param>
    /// <returns></returns>
    IEnumerator DurationRoutine( float waveDuration)
    {
        isWavePlaying = true;
        yield return new WaitForSeconds(waveDuration);
        isWavePlaying = false;;
    }

    /// <summary>
    /// 적 생성 루틴. 
    /// </summary>
    /// <param name="spawnPerSeconds"></param>
    /// <returns></returns>
    IEnumerator SpawnRoutine(int spawnPerSeconds)
    {
        while(isWavePlaying)
        {
            for(int i=0;i< spawnPerSeconds;i++)
            {
                Instantiate( prefab_enemy ).GetComponent<Enemy>().Init(clearedWaveNum);    // 여기서 스폰 위치 찾아야함. 
            }
            
            
            
            yield return new WaitForSeconds(1f);
        }

    }

}
