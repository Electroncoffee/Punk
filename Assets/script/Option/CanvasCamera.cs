using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCamera : MonoBehaviour
{
    private void Start()
    {//카메라 렌더를 위해 추가
        this.gameObject.GetComponent<Canvas>().worldCamera = camMoveMent.Instance.gameObject.GetComponent<Camera>();

    }
}
