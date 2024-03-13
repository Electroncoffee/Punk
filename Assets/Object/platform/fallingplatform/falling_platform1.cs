using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling_platform1 : MonoBehaviour
{
    public float fall_wait_time;
    public float recover_wait_time;
    private bool flag;
    private EdgeCollider2D bc;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        bc = GetComponent<EdgeCollider2D>();
        flag = true;
        anim.SetFloat("breakTime", 1/fall_wait_time);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && flag)
        {
            flag = false;
            anim.Play("break2_");
            Invoke("falling", fall_wait_time);
            Invoke("recover", (recover_wait_time + fall_wait_time));
            flag = true;
        }
    }
    void falling()
    {
        anim.Play("destroy2_");
        bc.enabled = false;
    }
    void recover()
    {
        anim.Play("idle2_");
        bc.enabled = true;
    }
}