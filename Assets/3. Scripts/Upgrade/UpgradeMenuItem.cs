using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeMenuItem : MonoBehaviour
{
    int type;
    int grade;
    int value;

    [SerializeField] TextMeshProUGUI txt_type;
    [SerializeField] TextMeshProUGUI txt_grade;
    [SerializeField] TextMeshProUGUI txt_value;

    public void Construct(int type, int grade, int value)
    {
        Debug.Log($"type : {type}, grade : {grade}, value : {value}");


    }
}
