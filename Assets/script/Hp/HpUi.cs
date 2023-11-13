using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HpUi : MonoBehaviour
{

    //사용중인 하트 UI를 모아놓은 집합체
    public Image[] Heart;

    public PlayerDataScriptableObject scriptable;

    //읽는건 자유, 쓰는 건 private로 표기한다.
    public int Hp { get; private set; }
    //Hp의 최대치 정의
    private int max_hp;
    //앞에 그려질 것과 뒤에 그려질 것
    public Sprite Back, Front;

    public void StartSetHpUI(int maxhp, int hp)
    {
        //Hp_Max의 사이즈를 정의
        this.max_hp = maxhp;

        //Hp 초기화.
        this.Hp = hp;

        //Front 이미지 모두 제거
        for (int i = 0; i < 5; i++)
            Heart[i].sprite = Back;

        //Front 이미지 초기화
        for (int i = 0; i < Hp; i++)
            Heart[i].sprite = Front;

        //현재 체력만큼만 활성화
        for (int i = 0; i < 5; i++)
            if (max_hp <= i-1)
            {
                Heart[i].gameObject.SetActive(false);
            }
    }

    public void SetHpUI(int val)
    {
        //Hp 감소
        Hp += val;

        //Hp가 0밑으로 내려가면 0으로 고정하고, Hp_Max를 초과하려고 하면 Hp_Max로 고정함.
        Hp = Mathf.Clamp(Hp, 0, max_hp);

        //Front 이미지 모두 제거
        for (int i = 0; i < max_hp; i++)
            Heart[i].sprite = Back;

        //Front 이미지 그리기
        for (int i = 0; i < max_hp; i++)
            if (Hp > i)
            {
                Heart[i].sprite = Front;
            }
    }
}
