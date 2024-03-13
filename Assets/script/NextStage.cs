using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NextStage : MonoBehaviour
{
    public UnityEvent<string> next;
    [SerializeField]
    string scene;
    private void OnTriggerEnter2D(Collider2D col) {
        next.Invoke(scene);
    }
}
