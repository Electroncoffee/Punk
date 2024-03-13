using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_Save : MonoBehaviour
{//스테이지 전환시 정보저장을 위한 코드, 체력,기술해금여부 저장
    public static Temp_Save instance;
    [SerializeField]
    int hp;
    [SerializeField]
    bool[] skill = new bool[3];
    public bool flag;
    private void Start()
    {
        flag = false;
        instance = this;
    }
    public void update_savedata()
    {
        Debug.Log("업데이트됨");
        flag = true;
        skill = GameObject.Find("player").GetComponent<playerMoveMent>().return_skill_value();
        hp = GameObject.Find("HPUI").GetComponent<hp>().return_hp();
    }
    public int loadhp()
    {
        return hp;
    }
    public bool[] loadskill()
    {
        return skill;
    }
}
