using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelectPanel : MonoBehaviour
{
    [SerializeField] EnemyDataSO enemyDataSO;

    public void SelectEasyMode()
    {
        enemyDataSO.maxHp = 65;
        SceneManager.LoadScene("2_Main");
    }

    public void SelectNormalMode()
    {
        enemyDataSO.maxHp = 100;
        SceneManager.LoadScene("2_Main");
    }

    public void SelectHardMode()
    {
        enemyDataSO.maxHp = 135;
        SceneManager.LoadScene("2_Main");
    }
}
