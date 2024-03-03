using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;
using UnityEngine.UI;

public class HpUi : MonoBehaviour
{

    //읽는건 자유, 쓰는 건 private로 표기한다.
    public int Hp { get; private set; }
    //Hp의 최대치 정의
    private int max_hp = 3;

    public Animator anim;
    enum animList { Hp3Idle, Hp3Reduce, Hp2Idle, Hp2Reduce, Hp1Idle, Hp1Reduce, Hp0Idle }
    public void StartSetHpUI(int maxhp)
    {
        //Hp_Max의 사이즈를 정의
        max_hp = maxhp;

        //Hp 초기화.
        Hp = maxhp;

        switch (Hp)
        {
            case 0:
                anim.Play("Hp0Idle");
                break;

            case 1:
                anim.Play("Hp1Idle");
                break;

            case 2:
                anim.Play("Hp2Idle");
                break;

            case 3:
                anim.Play("Hp3Idle");
                break;

            default:
                break;

        }

    }

    // 경우의 수
    /*

    Hp 3->2  / 2->3
    Hp 2->1  / 1->2
    Hp 1->0

    총 5가지

    HP3Idle -> Hp3Reduce -> Hp2Idle

    Hp2Idle -> Hp3Reduce(역재생) -> Hp3Idle

    Hp2Idle -> Hp2Reduce -> Hp1Idle

    체력 감소 이벤트가 발생할 때 함께 사용되며 UI를 변경하는 스크립트를 목표로함
    */

    public void Dameged(int d)
    {
        Hp -= d;
        Mathf.Clamp(Hp, 0, max_hp);
        if (Hp == 2)
        {
            anim.Play("Hp3Reduce");
        }
        else if (Hp == 1)
        {
            anim.Play("Hp2Reduce");
        }
        else if (Hp == 0)
        {
            anim.Play("Hp1Reduce");
        }
    }
    public void SetHpUI(int val)
    {
        //Hp 감소
        Hp += val;

        //Hp가 0밑으로 내려가면 0으로 고정하고, Hp_Max를 초과하려고 하면 Hp_Max로 고정함.
        Hp = Mathf.Clamp(Hp, 0, max_hp);

    }
}
