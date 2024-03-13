using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class spikeTrap : MonoBehaviour
{
    public float AppearTime;
    public float DisAppearTime;
    public bool OffBeat;
    private BoxCollider2D bc;
    private SpriteRenderer sr;
    private Animator anim;
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        if (OffBeat) StartCoroutine(Toggle2());
        else StartCoroutine(Toggle());
    }
    private IEnumerator Toggle()
    {
        while (true)
        {
            bc.enabled = false;
            anim.Play("Down_");
            yield return new WaitForSeconds(AppearTime);
            bc.enabled = true;
            anim.Play("Up_");
            yield return new WaitForSeconds(DisAppearTime);
        }
    }
    private IEnumerator Toggle2()
    {
        while (true)
        {
            bc.enabled = true;
            anim.Play("Up_");
            yield return new WaitForSeconds(DisAppearTime);
            bc.enabled = false;
            anim.Play("Down_");
            yield return new WaitForSeconds(AppearTime);
        }
    }
}