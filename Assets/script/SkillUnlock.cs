using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUnlock : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.name == "player")
                col.gameObject.GetComponent<playerMoveMent>().canwalljump = true;
    }
}
