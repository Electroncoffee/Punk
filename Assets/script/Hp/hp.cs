using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class hp : MonoBehaviour
{
    const int maxhp = 3;
    [SerializeField]
    int current_hp;
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
        if (Temp_Save.instance.flag)
        {
            current_hp = Temp_Save.instance.loadhp();
            hpUi.StartSetHpUI(Temp_Save.instance.loadhp());
        }
        else
        {
            current_hp = maxhp;
            hpUi.StartSetHpUI(maxhp);
        }
        
    }
    public void damage(int d){
        current_hp -= d;
        hpUi.Dameged(d);
        
        if(current_hp > 0){
            getDamage.Invoke(); //캐릭터 피해모션 재생함수
            Fade.instance.Transition(0.1f,5);
        }
        else
        {
            dead.Invoke();//사망모션
        }
    }
    public int return_hp() { return current_hp; }
}
