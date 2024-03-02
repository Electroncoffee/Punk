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
    public List<key> keys = new List<key>();//열쇠 리스트
    public int coin;
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
    public void getCoin(int num) //num만큼 coin변동
    {
        if (coin + num < 0) //코인이 음수로 되는거 예외처리
            return;
        coin += num;
    }
    public void getKey(string name,int cnt){
        int idx = containsKey(name);
        if(idx != -1){
            keys[idx].keyCount += cnt;
        }else{
            keys.Add(new key(name,cnt));
        }
    }
    public int containsKey(string keyName){
        for(int i=0; i<keys.Count; i++){
            if(keys[i].keyName == keyName){//key를 찾으면 인덱스를 리턴하고,못찾으면 -1 리턴
                return i;
            }
        }
        return -1;
    }
    public bool containsKeyOver(string name,int cnt){//키를 찾아서 일정 갯수 이상일때 true 리턴
        int idx = containsKey(name);
        if(idx != -1){
            if(keys[idx].keyCount >= cnt){
                return true;
            }
        }
        return false;
    }
    public void removeKey(string name,int cnt){
        int idx = containsKey(name);
        if(idx != -1){
            if(keys[idx].keyCount>cnt){
                keys[idx].keyCount -= cnt;
            }else{
                keys.RemoveAt(idx);
            }
        }
    }
    public void resetKey(){
        keys.Clear();
    }
    public void keyPrint(){
        foreach(key k in keys){
            Debug.Log(k.keyName + " : " + k.keyCount);
        }
    }
}

[System.Serializable]
public class key
{
    public key(string name,int count){
        this.keyName = name;
        this.keyCount = count;
    }
    public string keyName;
    public int keyCount;
}