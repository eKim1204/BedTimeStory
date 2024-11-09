using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionPanel : MonoBehaviour
{
    public void ToMainMenu()
    {
        SceneManager.LoadScene("1_Lobby");
    }

    public void Retry()
    {
        SceneManager.LoadScene("2_Main");
    }
}
