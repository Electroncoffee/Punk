using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/*
    현재 저장 데이터
    열쇠리스트, 체력, 씬, 데스카운트 저장
    열쇠 클래스 => 이름, 갯수 저장 (추가, 삭제, 탐색 기능 함수)
    
    체력 => 최대체력(상수), 시작최대체력(상수), 현재최대체력, 현제체력 (
*/
[CreateAssetMenu(fileName = "playerData", menuName = "ScriptableObject/playerData")]
public class PlayerDataScriptableObject : ScriptableObject
{
    const int max_health = 3;
    const int start_health = 3;
    public int current_max_health;
    public int health;
    public string sceneName;
    public int deadCnt;
    public void setSceneName(string name){
        sceneName = name;
    }
    public string returnSceneName()
    {
        return sceneName;
    }
}