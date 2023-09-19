using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject player;
    public void GameSceneCtrl(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
        player.SetActive(true);
        player.transform.position = GameObject.Find("Start").transform.position;
        //플레이어 옮기기
    }
    public void EnterMain()
    {
        SceneManager.LoadScene("StartScene");
        player.SetActive(false);
        player.transform.position = new Vector3 (0, 0, 0);
    }
}
