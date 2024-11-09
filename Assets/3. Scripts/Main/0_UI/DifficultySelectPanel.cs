using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelectPanel : MonoBehaviour
{
    [SerializeField] List<EnemyDataSO> enemyDataSOs = new();

    public void SelectEasyMode()
    {
        foreach(var ed in enemyDataSOs)
            ed.maxHp = 65;
        SceneManager.LoadScene("2_Main");
    }

    public void SelectNormalMode()
    {
        foreach (var ed in enemyDataSOs)
            ed.maxHp = 100;
        SceneManager.LoadScene("2_Main");
    }

    public void SelectHardMode()
    {
        foreach (var ed in enemyDataSOs)
            ed.maxHp = 135;
        SceneManager.LoadScene("2_Main");
    }
}
