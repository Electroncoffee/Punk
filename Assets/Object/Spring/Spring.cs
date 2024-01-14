using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public float spring_jumpforce;
    private float time;
    private EdgeCollider2D bc;
    private Animator anim;
    void Start()
    {
        time = 0.5f;
        anim = GetComponent<Animator>();
        bc = GetComponent<EdgeCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            anim.Play("Jump_");
            collision.gameObject.GetComponent<playerMoveMent>().Jump(spring_jumpforce);
            Invoke("Idle", time);
        }
    }
    void Idle()
    {
        anim.Play("Idle_");
    }
}
