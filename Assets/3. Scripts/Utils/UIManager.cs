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
            
            if(UpgradePanel.activeSelf)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
