using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exclamation_mark : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sr;
    private void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        sr.color = Color.clear;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "player") anim.Play("Exclamation mark");
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "player") anim.Play("Exclamation mark off");
    }
    void sr_on()
    {
        sr.color = Color.white;
    }
    void sr_off()
    {
        sr.color = Color.clear;
    }
}
