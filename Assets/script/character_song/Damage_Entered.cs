using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Entered : MonoBehaviour
{
    [SerializeField]
    Transform tel_trans;
    [SerializeField]
    hp health;
    bool hit = true;
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.layer == 9 && hit)
        {
            hit = false;
            Debug.Log("적과의 충돌");
            health.damage(1);
            if (health.return_hp() > 0) Invoke("teleport", 0.3f);
            Invoke("hit_on", 1f);
        }
    }
    void teleport()
    {
        transform.position = tel_trans.position;
    }
    void hit_on()
    {
        hit = true;
    }
}
