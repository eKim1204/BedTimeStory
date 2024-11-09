using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    //
    void Start()
    {
        StartGame();
    }


    public void StartGame()
    {
        tower.Init();
        
        GameEventManager.Instance.onGameStart.Invoke();
    }



}
