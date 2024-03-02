using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    [SerializeField]
    GameObject opt;
    void Awake()
    {
        opt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.Instance.GetKeyDownP(KeyMap.Menu))
        {
            opt.SetActive(!opt.activeSelf);
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        }
    }
}
