using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn_GameStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SceneLoadManager.Instance.Load_MainScene);
    }
}
