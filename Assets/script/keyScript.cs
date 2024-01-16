using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyScript : MonoBehaviour
{
    public PlayerDataScriptableObject currentData;
    public string keyName;
    public int count;

    void OnTriggerEnter2D(Collider2D other){
        currentData.getKey(keyName, count);
        this.gameObject.SetActive(false);
    }
}
