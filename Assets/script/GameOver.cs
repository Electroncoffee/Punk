using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{//사망시 활성화되며 Act키 입력시 재시작됨
    void Update()
    {//사망시 활성화
        if (InputManager.Instance.GetKeyP(KeyMap.Act))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
