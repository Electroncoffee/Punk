using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class footBoard : MonoBehaviour
{
    public UnityEvent press;
    public UnityEvent pressDown;
    public UnityEvent pressOut;
    public Sprite[] Switch;
    private bool lastcol = false;
    private BoxCollider2D col;
    private SpriteRenderer sr;

    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(col.IsTouchingLayers(LayerMask.GetMask("player","moveObject"))){
            press.Invoke();
            if(!lastcol){
                pressDown.Invoke();
                sr.sprite = Switch[1];
            }
            lastcol = true;
        }else{
            if(lastcol){
                pressOut.Invoke();
                sr.sprite = Switch[0];
            }
            lastcol = false;
        }
    }
}
