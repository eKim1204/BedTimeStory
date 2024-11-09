using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveInfo
{
    public int num; 
    
    public float duration;

    public int spawnPerSeconds;     // 초당 적 생성수 
}

[CreateAssetMenu(fileName = "WaveData", menuName = "SO/WaveData", order = int.MaxValue)]
public class StageWaveInfoSO: ScriptableObject
{
    public List<WaveInfo> waveInfos = new();
}
