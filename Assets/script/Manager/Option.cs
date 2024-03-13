using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    public static Option instance;
    [SerializeField]
    GameObject opt;
    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        opt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.Instance.GetKeyDownP(KeyMap.Menu))
        {
            MenuIO();
        }
    }
    public void MenuIO()
    {
        opt.SetActive(!opt.activeSelf);
        Time.timeScale = opt.activeSelf ? 0 : 1;
    }
}
