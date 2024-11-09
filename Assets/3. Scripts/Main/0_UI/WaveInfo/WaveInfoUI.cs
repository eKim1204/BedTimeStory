using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

using DG.Tweening;

public class WaveInfoUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text_waveNum;
    [SerializeField] TextMeshProUGUI text_waveTime;

    [SerializeField] ToastMessage toastMessage;  // 웨이브 시작시 토스트 메시지 - 추후 디테일수정
     
    


    //
    void Awake()
    {
        GameEventManager.Instance.onGameStart.AddListener(InitUI);
        GameEventManager.Instance.onWaveStart.AddListener(OnWaveStart);
    }


    void Update()
    {
        UpdateWaveTime();
    }



    void InitUI()
    {
        toastMessage.Init();
    }

    void OnWaveStart()
    {
        text_waveNum.SetText($"Wave : {WaveManager.Instance.currWaveNum}");

        toastMessage.OnWaveStart();// 토스트 메시지도 업데이트 
    }


    void UpdateWaveTime()
    {   
        if (WaveManager.Instance.isWavePlaying ==false )
        {   
            return;
        }
        float waveTime = WaveManager.Instance.wavePlayTime;

        int min  = (int)waveTime/60;
        int sec = (int)waveTime%60;
        
        text_waveTime.SetText($"Time: {min:00}:{sec:00}");


    }
}
