using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] Button closeButton;
    [SerializeField] Button rerollButton;
    [SerializeField] Button recoverHPButton;
    [SerializeField] Transform upgradeMenu;
    List<UpgradeMenuItem> upgradeMenuItems = new List<UpgradeMenuItem>();
    List<Dictionary<string, object>> dataset;

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
        ShowUpgradeMenus();
    }

    void ShowUpgradeMenus()
    {
        foreach (var upgradeMenuItem in upgradeMenuItems)
        {
            int randomNumber = UnityEngine.Random.Range(0, dataset.Count);
            randomNumber = dataset.Count - 1;
            var row = dataset[randomNumber];

            int type = Convert.ToInt32(row["Type"]);
            int grade = Convert.ToInt32(row["Grade"]);
            int value = Convert.ToInt32(row["Value"]);

            upgradeMenuItem.Construct(type, grade, value);
        }
    }
}
