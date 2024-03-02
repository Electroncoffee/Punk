using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyText : MonoBehaviour
{
    [SerializeField]
    Text text;
    [SerializeField]
    KeyMap key;
    void Update()
    {
        text.text = InputManager.Instance.ReturnKey(key).ToString();
    }
}
