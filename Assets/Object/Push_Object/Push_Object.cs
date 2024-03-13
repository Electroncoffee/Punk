using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Push_Object : MonoBehaviour
{
    public float ObjectDrag;
    public float ObjectLimit;
    private Rigidbody2D rb;
    private bool lastcol = false;
    private BoxCollider2D col;
    Object_Sound sound;
    void Start()
    {
        sound = GetComponent<Object_Sound>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        check_air();//공중인지를 확인하고 공중이면 속도정지 이후 수직낙하하게
        if (Mathf.Round(rb.velocity.magnitude) != 0)
        {
            if (!sound.isplay())
                sound.PlaySfx(0);
        }
        else
            sound.StopSfx();
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