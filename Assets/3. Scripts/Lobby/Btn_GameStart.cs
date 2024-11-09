using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn_GameStart : Btn_Parent
{
    public override void Init()
    {
        GetComponent<Button>().onClick.AddListener(SceneLoadManager.Instance.Load_MainScene);
    }


}
