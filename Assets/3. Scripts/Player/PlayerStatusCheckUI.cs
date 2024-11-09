using Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatusCheckUI : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text reloadingText;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.AddListener(MEventType.ChangeArmo, ChangeArmoText);
        EventManager.Instance.AddListener(MEventType.ReloadingArmo, ReloadingText);
    }

    private void ChangeArmoText(MEventType MEventType, Component Sender, EventArgs args = null)
    {
        TransformEventArgs tArgs = args as TransformEventArgs;
        text.text = string.Format("{0}/{1}",tArgs.value[0].ToString(),tArgs.value[1].ToString());
    }
    private void ReloadingText(MEventType MEventType, Component Sender, EventArgs args = null)
    {
        TransformEventArgs tArgs = args as TransformEventArgs;
        bool value = bool.Parse(tArgs.value[0].ToString());

        reloadingText.gameObject.SetActive(value);
    }
}
