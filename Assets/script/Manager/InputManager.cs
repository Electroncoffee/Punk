using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 싱글톤하여 인스턴스로 접근 가능
 딕셔너리는 함부로 접근 못하게 private처리 했음
 해당 시리얼라이즈딕셔너리는 인스펙터창에서 딕셔너리 볼 수 있게 설정한거
 초기설정은 Awake에서 해주고 나중에 설정창에서 바뀌면 변경되게
 이곳에 모든 키매핑해주고 다른 cs에선 인스턴스 따서 P함수사용
 */
public enum KeyMap
{
    Up,//0
    Down,//1
    Left,//2
    Right,//3
    Jump,//4
    Crouch,//5
    Dash,//6
    Act,//7
    Menu//8
}
public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    [SerializeField]
    SerializableDictionary<KeyMap, KeyCode> KeyValuePairs = new() {
        { KeyMap.Up,KeyCode.W},
        { KeyMap.Down,KeyCode.S},
        { KeyMap.Left,KeyCode.A},
        { KeyMap.Right,KeyCode.D},
        { KeyMap.Jump,KeyCode.Space },
        { KeyMap.Crouch,KeyCode.LeftControl},
        { KeyMap.Dash,KeyCode.LeftShift},
        { KeyMap.Act,KeyCode.F},
        { KeyMap.Menu,KeyCode.Escape}
    };
    private int InputKey=-1;
    void Awake()
    {
        Instance = this;
    }
    public KeyCode ReturnKey(KeyMap key)
    {
        return KeyValuePairs[key];
    }
    public bool GetKeyUpP(KeyMap key)
    {
        return Input.GetKeyUp(ReturnKey(key));
    }
    public bool GetKeyDownP(KeyMap key)
    {
        return Input.GetKeyDown(ReturnKey(key));
    }
    public bool GetKeyP(KeyMap key)
    {
        return Input.GetKey(ReturnKey(key));
    }
    public float GetRawHorizon()
    {
        if (GetKeyP(KeyMap.Left))
            return -1f;
        else if (GetKeyP(KeyMap.Right))
            return 1f;
        else
            return 0f;
    }
    private void OnGUI()
    {
        Event KeyEvent = Event.current;
        if (KeyEvent.isKey&&InputKey!=-1)
        {
            Debug.Log("키매핑 입력됨: "+InputKey+" "+KeyEvent.keyCode);
            KeyValuePairs[(KeyMap)InputKey] = KeyEvent.keyCode;
            Debug.Log("변경된 값: " + KeyValuePairs[(KeyMap)InputKey]);
            InputKey = -1;
        }
    }
    public void EditKey(int input)
    {
        InputKey = input;
    }
    public void LogKey(string key)
    {
        Debug.Log(KeyValuePairs[(KeyMap)System.Enum.Parse(typeof(KeyMap), key)]);
    }
}