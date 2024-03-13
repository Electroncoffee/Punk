using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Last_Scene : MonoBehaviour
{
    Animator anim;
    [SerializeField]
    GameObject credit;
    bool flag = false;
    public UnityEvent<string> next;
    [SerializeField]
    string scene;
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(LastScene());
    }
    void Update()
    {
        if (flag)
        {
            if (InputManager.Instance.GetKeyUpP(KeyMap.Act))
            {
                TalkManager.Instance.next_dialogue();
            }
            if(TalkManager.Instance.visible.activeSelf==false)
            {
                credit.SetActive(true);
                StartCoroutine(Reset());
            }
        }
    }
    IEnumerator LastScene()
    {
        Fade.instance.Transition_Out();
        yield return new WaitForSeconds(1f);
        anim.Play("dead_");
        yield return new WaitForSeconds(2f);
        TalkManager.Instance.start_dialogue("continue.xml");
        flag = true;
    }
    IEnumerator Reset()
    {

        yield return new WaitForSeconds(11f);
        next.Invoke(scene);
    }
}
