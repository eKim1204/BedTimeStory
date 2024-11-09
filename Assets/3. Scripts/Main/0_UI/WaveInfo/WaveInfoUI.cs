using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class WaveInfoUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text_waveNum;
    [SerializeField] TextMeshProUGUI text_waveTime;

    // [SerializeField] TextMeshProUGUI text_waveTime;  // 웨이브 시작시 토스트 메시지
     
    
    //
    void Awake()
    {
        GameEventManager.Instance.onWaveStart.AddListener(OnWaveStart);

    }


    void Update()
    {


    }




    void OnWaveStart()
    {
        text_waveNum.SetText($"Wave : {WaveManager.Instance.currWaveNum}");
        // 토스트 메시지도 업데이트 
    }


    void UpdateWaveTime()
    {   
        float waveTime = WaveManager.Instance.wavePlayTime;

        int min  = (int)waveTime/60;
        int sec = (int)waveTime%60;
        
        text_waveNum.SetText($"Time: {min:00}:{sec:00}");


    }
}
