using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public Transform[] desPos;
    public Transform chasingpos;
    public float platform_speed;
    public float delay;
    public bool platform_is_move;
    // Start is called before the first frame update
    void Start()
    {
        chasingpos = desPos[1];
        InvokeRepeating("check_pos", 0.1f, 0.1f);
    }
    //플레이어가 플랫폼에 탑승하면 같이 움직이게 위치를 자식으로 옮기기
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
    void FixedUpdate()
    {
        if (platform_is_move)
            transform.position = Vector2.MoveTowards(transform.position, chasingpos.position, Time.deltaTime * platform_speed);
    }
    void check_pos()
    {
        for (int i = 0; i < desPos.Length; i++)
        {
            if (transform.position == desPos[i].position)
            {
                Debug.Log("도착 좌표변경" + i);
                if (i != desPos.Length - 1)
                    StartCoroutine(change_chasingpos(i+1));
                else
                    StartCoroutine(change_chasingpos(0));
            }
        }
    }
    public void platform_move()
    {
        platform_is_move = true;
    }
    public void platform_stop()
    {
        platform_is_move = false;
    }

    IEnumerator change_chasingpos(int num)
    {
        yield return new WaitForSeconds(delay);
        chasingpos = desPos[num];
    }
}
