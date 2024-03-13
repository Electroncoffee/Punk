using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Continue : MonoBehaviour
{
    public UnityEvent<string> next;
    [SerializeField]
    string scene;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name== "player")
        {
            col.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Fade.instance.Transition_In();
            StartCoroutine(delay());
        }
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(3f);
        next.Invoke(scene);
    }
}
