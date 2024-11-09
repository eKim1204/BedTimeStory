using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : DestroyableSingleton<GamePlayManager>
{   Tower _tower;
    public Tower tower 
    {
        get
        {
            if( _tower== null)
            {
                _tower = FindObjectOfType<Tower>();
            }
            return _tower;
        }
    }



    [SerializeField] Button testWaveStartBtn;

    //
    void Start()
    {
        testWaveStartBtn.onClick.AddListener(  StartWave );
        
        StartGame();
    }


    public void StartGame()
    {
        tower.Init();
        
        GameEventManager.Instance.onGameStart.Invoke();


        Debug.Log("게임 시작");
    }

    
    public void StartWave()
    {
        Debug.Log("웨이브 시작");
        WaveManager.Instance.FinishWave();
        WaveManager.Instance.StartWave();

        
    }

}
