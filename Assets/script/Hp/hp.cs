using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class hp : MonoBehaviour
{
    public UnityEvent getDamage;
    public UnityEvent<int> getDamage_UI;
    //public UnityEvent dead;
    public UnityEvent getHeal;
    public UnityEvent<int> getHeal_UI;
    public HpUi hpUi;
    public PlayerDataScriptableObject currentData;
    public PlayerDataScriptableObject lastData;
    /*
    게임시작 & 스테이지 전환 & 사망 시 Start함수 동작
    게임시작 & 스테이지 전환시 lastdata 갱신
    사망시 lastdata 통해서 정보 불러오기
    */
    private void Start()
    {
        if (currentData.deadCnt != lastData.deadCnt)
        {
            //죽었을때
            hpUi.StartSetHpUI(lastData.current_max_health, currentData.health);
            lastData.deadCnt = currentData.deadCnt;
        }
        else
        {
            //새 스테이지에 왔을때 lastData 정보 갱신
            lastData.coin = currentData.coin;
            lastData.current_max_health = currentData.current_max_health;
            lastData.health = currentData.health;
            //lastData.keys = currentData.keys.ToList<key>();//얕은 복사
            lastData.keys = currentData.keys.ConvertAll(k => new key(k.keyName, k.keyCount));//깊은 복사
            lastData.setSceneName(SceneManager.GetActiveScene().name);
        }
        //체력ui 재실행
        hpUi.StartSetHpUI(currentData.current_max_health,currentData.health);
    }
    public void damage(int d){
        currentData.health -= d;
        getDamage.Invoke(); //캐릭터 피해모션 재생함수
        getDamage_UI.Invoke(currentData.health); //UI 갱신
        if(currentData.health <= 0){
            loadLastData();
        }
    }
    public void heal(int d)
    {
        //회복가능
        if ((currentData.health + d) <= currentData.current_max_health)
            currentData.health += d;
        else//최대체력이라 회복불가
            currentData.health = currentData.current_max_health;
        getHeal.Invoke(); //캐릭터 회복모션(이펙트) 재생함수
        getHeal_UI.Invoke(currentData.health); //UI 갱신
        Debug.Log(currentData.health);
    }
    public void setHp(int hp){
        currentData.health = hp;
    }
    public int return_hp() { return currentData.health; }
    public bool is_max() { return currentData.current_max_health == currentData.health; }
    //리스폰 할때 currentData.current_health스크립트 dead이벤트랑 연결 ,죽으면 씬 로딩 다시
    public void loadLastData()
    {
        currentData.coin = lastData.coin;//스테이지 시작할때의 데이터를 현재 데이터에 저장
        currentData.health = lastData.health;
        //currentData.keys = lastData.keys.ToList<key>();//얕은 복사
        currentData.keys = lastData.keys.ConvertAll(k => new key(k.keyName, k.keyCount));//깊은 복사
        currentData.deadCnt++;//죽은 횟수 추가
        SceneManager.LoadScene(lastData.sceneName);
    }
}
