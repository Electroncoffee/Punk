using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class hp : MonoBehaviour
{
    const int maxhp = 3;
    int current_hp = 3;
    public UnityEvent getDamage;
    public UnityEvent dead;
    public HpUi hpUi;
    /*
    게임시작 & 스테이지 전환 & 사망 시 Start함수 동작
    게임시작 & 스테이지 전환시 lastdata 갱신
    사망시 lastdata 통해서 정보 불러오기
    */
    private void Start()
    {
        hpUi.StartSetHpUI(maxhp);
    }
    public void damage(int d){
        current_hp -= d;
        hpUi.Dameged(d);
        
        if(current_hp > 0){
            getDamage.Invoke(); //캐릭터 피해모션 재생함수
        }
        else
        {
            dead.Invoke();//사망모션
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            damage(1);//데미지 입히기
        }
    }
}
