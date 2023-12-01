using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HP : MonoBehaviour
{
    
    public Image[] Heart;



    public hp hp_control;


    public Sprite Back, Front;


    void Start()
    {

        //Heart 배열의 최대값을 hp.cs의 MaxHp로 초기화
        for(int i =0;i < hp_control.Hp;i++)
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
        for(int i =0;i < hp_control.Hp;i++)
        {
            Heart[i].sprite = Front;
        }
    }

    public void SetHp(int d)
    {

        hp_control.Hp += d;

        hp_control.Hp = Mathf.Clamp(hp_control.Hp,0,hp_control.MaxHp);

       //Front 이미지 모두 제거
        for (int i = 0; i < hp_control.MaxHp; i++)
            Heart[i].sprite = Back;

        //Front 이미지 그리기
        for (int i = 0; i < hp_control.MaxHp; i++)
            if (hp_control.Hp > i)
            {
                Heart[i].sprite = Front;
            }
        
    }
}
