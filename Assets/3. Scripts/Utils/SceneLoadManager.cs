using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : Singleton<SceneLoadManager>
{
    public static readonly string lobbySceneName = "1_Lobby";
    public static readonly string mainSceneName = "2_Main";

    bool isLoading;

    [SerializeField] bool isCompleted_sceneLoaded;

    
    
    
    public override void Init()
    {

    }




    //====================
    // 비동기 씬 호출 : sceneName에 해당하는 씬을 비동기적으로 로드한다. 
    //===================
    public void LoadScene(string sceneName)
    {
        if( isLoading )
        {
            return;
        }
        isLoading = true;

        StartCoroutine(LoadScene_async(sceneName)); // 씬 전환 작업
    }

    IEnumerator LoadScene_async(string sceneName)
    {       
        // 비동기 씬호출
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;
        isCompleted_sceneLoaded = false;

        // 씬 로드 시 작업 
        while (asyncLoad.allowSceneActivation == false )
        {
            //
            yield return new WaitUntil(()=>asyncLoad.progress >= 0.9f) ;      // 메모리에 해당 씬 리소스 모두 올릴 때까지 대기  

            isCompleted_sceneLoaded = true;

            //
            asyncLoad.allowSceneActivation = true;      // 이거 하면 씬 넘어감
        }

        isLoading = false;

        
        OnSceneChanged();
    }

    void OnSceneChanged()
    {

    }

    //================================
    public void Load_Lobby()
    {
        LoadScene(lobbySceneName);
    }


    public void Load_MainScene()
    {
        LoadScene(mainSceneName);
    }

}
