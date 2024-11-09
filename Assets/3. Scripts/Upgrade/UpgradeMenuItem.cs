using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeMenuItem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txt_type;
    [SerializeField] TextMeshProUGUI txt_grade;
    [SerializeField] TextMeshProUGUI txt_value;
    [SerializeField] Button LockButton;
    private int type;
    private int grade;
    private int value;

    private bool isLocked = false;
    public bool IsLocked=>isLocked;

    void SetTypeTxt(int type)
    {
        switch (type)
        {
            case 0:
                txt_type.SetText("Power");
                break;
            case 1:
                txt_type.SetText("MoveSpeed");
                break;
            case 2:
                txt_type.SetText("ReloadSpeed");
                break;
            case 3:
                txt_type.SetText("Cooltime");
                break;
            default:
                txt_type.SetText("error type!");
                break;
        }
    }
    void SetGradeTxt(int grade)
    {
        txt_grade.SetText(((char)('A' + grade)).ToString());
    }
    void SetValueTxt(int value)
    {
        txt_value.SetText(value.ToString());
    }

    public void Construct(int type, int grade, int value)
    {
        Debug.Log($"type : {type}, grade : {grade}, value : {value}");

        SetTypeTxt(type);
        SetGradeTxt(grade);
        SetValueTxt(value);
    }

    public void OnLockButtonPressed()
    {
        isLocked = !isLocked;
        Debug.Log("Lock : " + isLocked);
    }
}
