using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private static SceneChange instance;

    
    //씬이 변경될때 기존의 씬의 Data를 보존하기 위해 하는 기법
    public static SceneChange Instance
    {
        get
        {
            if(instance == null)
            {
                Object obj = Resources.Load("Prefab/SceneChange");
                Instantiate(obj);
                SceneChange sc = FindObjectOfType<SceneChange>();
                instance = sc;

                DontDestroyOnLoad(instance);
            }
            return instance;
        }
    }

    public void Change(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
