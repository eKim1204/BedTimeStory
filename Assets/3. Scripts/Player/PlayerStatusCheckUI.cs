using DG.Tweening;
using Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusCheckUI : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text reloadingText;
    [SerializeField] private Image crosshair;
    [SerializeField] private Image crosshair2;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.AddListener(MEventType.ChangeArmo, ChangeArmoText);
        EventManager.Instance.AddListener(MEventType.ReloadingArmo, ReloadingText);
        EventManager.Instance.AddListener(MEventType.EnemyHitted, HittedEffect);
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
    private void HittedEffect(MEventType MEventType, Component Sender, EventArgs args = null)
    {
        TransformEventArgs tArgs = args as TransformEventArgs;
        var seq = DOTween.Sequence();
        seq
            .SetAutoKill(true)
            .OnStart(()=> crosshair.gameObject.SetActive(true))
            .Append(crosshair.transform.DOPunchScale(new Vector3(0.25f, 0.25f, 0f), 0.125f))
            .Join(crosshair2.transform.DOPunchScale(new Vector3(0.25f, 0.25f, 0f), 0.125f))
            .OnComplete(()=>crosshair.gameObject.SetActive(false));
    }
}
