using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeMenuItem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txt_grade;
    [SerializeField] TextMeshProUGUI txt_value;
    [SerializeField] Button LockButton;

    [SerializeField] Sprite lockedImage;
    [SerializeField] Sprite unlockedImage;

    [SerializeField] UpgradeSystem upgradeSystem;

    private int type;
    private int value;

    private bool isLocked = false;
    public bool IsLocked=>isLocked;

    void SetGradeTxt(int grade)
    {
        txt_grade.SetText(((char)('A' + grade)).ToString());
    }
    void SetValueTxt(int value)
    {
        if(type == 0)
        {
            txt_value.SetText(value.ToString());
        }
        if (type == 1)
        {
            txt_value.SetText(value.ToString());
        }
        if (type == 2)
        {
            txt_value.SetText(value.ToString() + " sec");
        }
        if (type == 3)
        {
            txt_value.SetText((value*10).ToString() + "%");
        }

    }

    public void Construct(int type, int grade, int value)
    {
        this.type = type;
        this.value = value;

        SetGradeTxt(grade);
        SetValueTxt(value);
    }

    public void OnLockButtonPressed()
    {
        isLocked = !isLocked;
        Debug.Log("Lock : " + isLocked);

        if(isLocked)
        {
            LockButton.GetComponent<Image>().sprite = lockedImage;
            upgradeSystem.onItemLocked.Invoke();
        }
        else
        {
            LockButton.GetComponent<Image>().sprite = unlockedImage;
            upgradeSystem.onItemLocked.Invoke();
        }
    }

    public void OnSelected()
    {
        if(type == 0)
        {
            PlayerStats.Instance.SetAttackPower(value);
        }
        else if (type == 1)
        {
            PlayerStats.Instance.SetMoveSpeed(value);
        }
        else if (type == 2)
        {
            PlayerStats.Instance.SetReloadSpeed(value);
        }
        else if (type == 3)
        {
            PlayerStats.Instance.SetSkillCooltime(value);
        }

        upgradeSystem.onItemSelected.Invoke();
    }
}
