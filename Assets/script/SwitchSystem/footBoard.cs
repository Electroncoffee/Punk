using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class footBoard : MonoBehaviour
{
    public bool Permanent;
    public Sprite[] Switch;
    public UnityEvent press;
    public UnityEvent pressDown;
    public UnityEvent pressOut;
    public BoxCollider2D col;
    private bool lastcol = false;
    private SpriteRenderer sr;

    void Start()
    {
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
            if(lastcol && !Permanent){
                pressOut.Invoke();
                sr.sprite = Switch[0];
            }
            lastcol = false;
        }
    }
}
