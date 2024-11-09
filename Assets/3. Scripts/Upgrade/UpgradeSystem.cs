using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] Button closeButton;
    [SerializeField] Button rerollButton;
    [SerializeField] Button hpRecoverButton;
    [SerializeField] Transform upgradeMenu;

    List<UpgradeMenuItem> upgradeMenuItems = new List<UpgradeMenuItem>();
    List<Dictionary<string, object>> dataset;

    [HideInInspector] public UnityEvent onItemLocked;

    float hpRecoverRate = 100;
    int hpRecoverCost = 100;
    int rerollCost = 0; // 처음 roll은 0원, reroll 시에는 코스트가 듬

    private void Awake()
    {
        dataset = CSVReader.Read("3. Database/UpgradeSystem");
        foreach(Transform child in upgradeMenu)
        {
            upgradeMenuItems.Add(child.GetComponent<UpgradeMenuItem>());
        }
    }

    private void Start()
    {
        onItemLocked.AddListener(ChangeRerollCost);

        Roll();
        SetRecoverButtonText();
    }

    private void Roll()
    {
        PlayerStats.Instance.UseGold(rerollCost);

        for (int i = 0; i < upgradeMenuItems.Count; i++)
        {
            var upgradeMenuItem = upgradeMenuItems[i];
            if (upgradeMenuItem.IsLocked)
                continue;

            // 타입 분류 오프셋
            int typeOffset = i * 6; // A~F까지 6개의 등급

            // 등급 분류 오프셋
            int gradeOffset;
            float randomNumber = UnityEngine.Random.Range(0, 100);
            if (randomNumber < 5)
                gradeOffset = 0;
            else if (randomNumber < 15)
                gradeOffset = 1;
            else if (randomNumber < 30)
                gradeOffset = 2;
            else if (randomNumber < 60)
                gradeOffset = 3;
            else if (randomNumber < 80)
                gradeOffset = 4;
            else // (randomNumber < 100)
                gradeOffset = 5;

            var row = dataset[typeOffset + gradeOffset];

            int grade = Convert.ToInt32(row["Grade"]);
            int value = Convert.ToInt32(row["Value"]);

            upgradeMenuItem.Construct(i, grade, value);
            upgradeMenuItem.OnSelected();
        }

        ChangeRerollCost();
    }

    private void SetRecoverButtonText()
    {
        hpRecoverButton.GetComponentInChildren<TextMeshProUGUI>().
            SetText($"HP {hpRecoverRate} recover : {hpRecoverCost}");
    }

    public void OnRecoverButtonPressed()
    {
        PlayerStats.Instance.UseGold(hpRecoverCost);
        PlayerStats.Instance.Recover(hpRecoverRate);

        hpRecoverCost *= 2;

        SetRecoverButtonText();
        SetButtonsInteractable();
    }

    public void OnRerollButtonPressed()
    {
        Roll();

        SetButtonsInteractable();
    }

    private void SetButtonsInteractable()
    {
        Debug.Log("button check");

        if(PlayerStats.Instance.CurrGold >= hpRecoverCost)
        {
            hpRecoverButton.interactable = true;
        }
        else
        {
            hpRecoverButton.interactable = false;
        }

        if (PlayerStats.Instance.CurrGold >= rerollCost)
        {
            rerollButton.interactable = true;
        }
        else
        {
            rerollButton.interactable = false;
        }
    }

    private void ChangeRerollCost()
    {
        int count = 0;
        foreach(var item in upgradeMenuItems)
        {
            if (item.IsLocked)
                count++;
        }

        if (count == 4) // 다 잠그면 reroll을 못하게
        {
            rerollButton.interactable = false;
            return;
        }
        else
        {
            rerollButton.interactable = true;
        }

        if (count == 0)
        {
            rerollCost = 100;
        }
        else if (count == 1)
        {
            rerollCost = 150;
        }
        else if (count == 2)
        {
            rerollCost = 300;
        }
        else if (count == 3)
        {
            rerollCost = 600;
        }

        rerollButton.GetComponentInChildren<TextMeshProUGUI>().SetText($"Reroll : {rerollCost}");
    }
}
