using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    void Start()
    {
        camMoveMent.Instance.Get_Player_Position(this.GetComponent<Transform>());
    }
}
