using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*F입력 시 플레이어 콜라이더와 충돌된 NPC레이어 오브젝트가 있으면 해당 오브젝트를 게임매니저에 전달*/
public class Scan_Object : MonoBehaviour
{
    GameObject ScanObject;
    playerMoveMent moveMent;
    Rigidbody2D rb;
    public bool isNPC; //NPC Trigger 충돌여부
    private void Start()
    {
        isNPC = false;
        moveMent = GetComponent<playerMoveMent>();
        rb=GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (InputManager.Instance.GetKeyUpP(KeyMap.Act) && isNPC) //트리거에 대화가능 오브젝트 진입시 F버튼으로 대화 진입
        {
            Debug.Log("다이얼로그 작동");
            
            if (rb.constraints == RigidbodyConstraints2D.FreezeRotation)
            {
                TalkManager.Instance.start_dialogue(ScanObject.GetComponent<NPC_info>().return_xmlname());
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }
            else
            {
                TalkManager.Instance.next_dialogue();
                if (!TalkManager.Instance.visible.activeSelf)
                    rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) //NPC 오브젝트와 충돌 시 플래그 변경 및 오브젝트 저장
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("NPC"))
        {
            isNPC = true;
            ScanObject = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) //충돌된 오브젝트 탈출 시 플래그 변경 및 오브젝트 삭제
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("NPC"))
        {
            isNPC = false;
            ScanObject = null;
        }
    }
}
