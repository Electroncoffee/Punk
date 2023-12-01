using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HpUi : MonoBehaviour
{
    //사용중인 하트 UI를 모아놓은 집합체
    public Image[] Heart;

    public PlayerDataScriptableObject scriptable;


    //읽는건 자유, 쓰는 건 private로 표기한다.
    public int Current_Hp;

    //Hp의 최대치 정의
    private int Hp_Max;

    //앞에 그려질 것과 뒤에 그려질 것
    public Sprite Back, Front;

    private void Awake()
    {        
        //Hp_Max의 사이즈를 정의
        Hp_Max = Heart.Length;

        //Hp 초기화.
        Current_Hp = Hp_Max;

        //Front 이미지 초기화
        for (int i = 0; i < Hp_Max; i++)
            if (Current_Hp > i)
            {
                Heart[i].sprite = Front;
            }
    }

    void Update()
    {
        foreach(Image img in Heart)
        {
            img.sprite = Back;
        }

        for(int i=0;i<Current_Hp;i++)
        {
            Heart[i].sprite = Front;
        }

    }

    public void SetHp(int val)
    {
        //Hp 감소
        Current_Hp += val;

        if(Current_Hp <= 0)
        {
            Debug.Log("Player is Dead");
            return;
        }

        //Hp가 0밑으로 내려가면 0으로 고정하고, Hp_Max를 초과하려고 하면 Hp_Max로 고정함.
        Current_Hp = Mathf.Clamp(Current_Hp, 0, Hp_Max);

        //Front 이미지 모두 제거
        for (int i = 0; i < Hp_Max; i++)
            Heart[i].sprite = Back;

        //Front 이미지 그리기
        for (int i = 0; i < Hp_Max; i++)
            if (Current_Hp > i)
            {
                Heart[i].sprite = Front;
            }
    }
}
