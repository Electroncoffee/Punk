using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Push_Object : MonoBehaviour
{
    public float ObjectDrag;
    public float ObjectLimit;
    public bool isLimit;
    private Rigidbody2D rb;
    private bool lastcol = false;
    private BoxCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        check_air();//공중인지를 확인하고 공중이면 속도정지 이후 수직낙하하게
        if(isLimit)
        {
            //check_limit();//플레이어 접촉위치를 기준으로 제한된 장소는 밀 수 없게
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                Debug.Log("충돌한 친구: " + collision.gameObject.name);
                Debug.Log("충돌위치: " + contact.point);
            }
        }
    }
    void check_air()
    {
        if (col.IsTouchingLayers(LayerMask.GetMask("ground")))
        {
            if (!lastcol)
            {
                rb.drag = ObjectDrag;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;

            }
            lastcol = true;
        }
        else
        {
            if (lastcol)
            {
                rb.drag = 0f;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation & RigidbodyConstraints2D.FreezePositionX;
            }
            lastcol = false;
        }
    }
}