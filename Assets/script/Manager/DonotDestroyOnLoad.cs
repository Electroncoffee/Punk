using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonotDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        Object.DontDestroyOnLoad(this.gameObject);
    }
}
