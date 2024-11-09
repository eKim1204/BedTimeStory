using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : DestroyableSingleton<UIManager>
{
    [SerializeField] GameObject UpgradePanel;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            UpgradePanel.SetActive(!UpgradePanel.activeSelf);
        }
    }
}
