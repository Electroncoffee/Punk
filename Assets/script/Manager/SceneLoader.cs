using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void GameSceneCtrl(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    public void GameSceneCtrl2(string SceneName)
    {
        Temp_Save.instance.update_savedata();
        SceneManager.LoadScene(SceneName);
    }
}
