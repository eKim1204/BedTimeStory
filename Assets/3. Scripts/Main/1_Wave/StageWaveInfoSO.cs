using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveInfo
{
    public int num; 
    
    public float duration;

    public float cycleGap;     // 사이클 간격
    public int spawnPerCycle;     // 사이클 당 적 생성 수
    
}

[CreateAssetMenu(fileName = "WaveData", menuName = "SO/WaveData", order = int.MaxValue)]
public class StageWaveInfoSO: ScriptableObject
{
    public List<WaveInfo> waveInfos = new();
}
