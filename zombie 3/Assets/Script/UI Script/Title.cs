using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public string sceneName = "GameStage";


    public static Title instance;

    private SaveNLoad theSaveNLoad;


    private void Awake()
    {


        if (instance == null)
        {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    else
    Destroy(this.gameObject);
}
    public void ClikStart()
    {
        Debug.Log("로딩");
        SceneManager.LoadScene(sceneName);
    }
    public void ClikLoad()
    {
        Debug.Log("로드");

        StartCoroutine(LoadCoroutine());
    }

    IEnumerator LoadCoroutine()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while(!operation.isDone)
        {
            yield return null;
        }

        theSaveNLoad = FindObjectOfType<SaveNLoad>();
        theSaveNLoad.LoadData();
        gameObject.SetActive(false);
    }


    public void ClikExit()
    {
        Debug.Log("게임 종료");
            Application.Quit();
    }
}