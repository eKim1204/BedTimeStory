using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_TowerHp : MonoBehaviour
{


    Slider slider_hp;
    
    //

    void Awake()
    {
        GameEventManager.Instance.onGameStart.AddListener( Init );
        GameEventManager.Instance.onChange_towerHp.AddListener( OnUpdateTowerHp);
    }


    void Init()
    {
        slider_hp = GetComponent<Slider>();
        slider_hp.maxValue = Tower.Instance.maxHp;
        slider_hp.value = Tower.Instance.hp;
    }

    void OnUpdateTowerHp()
    {
        slider_hp.value = Tower.Instance.hp;
    }




    
}
