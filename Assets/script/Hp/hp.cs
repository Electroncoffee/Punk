using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class hp : MonoBehaviour
{
    public int MaxHp = 10;
    public int Hp;
    public UnityEvent getDamage;
    public UnityEvent<int> getDamage_UI;
    public UnityEvent dead;
    public UnityEvent getHeal;
    public UnityEvent<int> getHeal_UI;
    public void damage(int d){

        Hp -= d;
        getDamage.Invoke();
        getDamage_UI.Invoke(d);
        if(Hp <= 0){
            dead.Invoke();
        }
    }
    public void heal(int d)
    {
        //ȸ������
        if ((Hp + d) <= MaxHp)
            Hp += d;
        else//�ִ�ü���̶� ȸ���Ұ�
            Hp = MaxHp;
        getHeal.Invoke();
        getHeal_UI.Invoke(d);
        Debug.Log(Hp);
    }
    public void setHp(int hp){
        Hp = hp;
    }
    public int return_hp() { return Hp; }
    public bool is_max() { return MaxHp == Hp; }
}
