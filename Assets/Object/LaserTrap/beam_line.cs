using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class beam_line : MonoBehaviour
{
    [SerializeField]
    RaycastHit2D[] hit;
    [SerializeField]
    ContactFilter2D filter_player;
    [SerializeField]
    ContactFilter2D filter_other;
    BoxCollider2D boxcol;
    SpriteRenderer sprite;
    private void Start()
    {
        hit=new RaycastHit2D[1];
        boxcol = this.GetComponent<BoxCollider2D>();
        sprite = this.GetComponent<SpriteRenderer>();
        boxcol.enabled = false;
        sprite.color = new Color(0, 0, 0, 0);
    }
    private void Update()
    {
        Physics2D.Raycast(transform.position, transform.up, filter_other, hit);
        boxcol.size = new Vector2((float)0.25, hit[0].distance);
        boxcol.offset = new Vector2(0, hit[0].distance / 2);
        sprite.size = new Vector2((float)0.25, hit[0].distance);
    }
    public void ready()
    {
        
    }
    public void shot()
    {
        boxcol.enabled = true;
        sprite.color = Color.white;
        //속도,시간,길이
        //deltatime은 1프레임당 시간
        //애니메이션은 타임라인이 프레임으로 사격프레임은 총 7프레임에 배율 0.03임
        //그러면 deltatime*0.03하면 도착시간이 애니메이션시간과 동일함
        //길이3,7프레임,1배율 => 1프레임에 3/7만큼이동 => 0.03배율이면 
    }
    public void reload()
    {
        boxcol.enabled = false;
        sprite.color = Color.clear;
    }
}