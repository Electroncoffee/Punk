using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonotDestroyOnLoad : MonoBehaviour
{
    public bool Active;
    private void Awake()
    {
        Object.DontDestroyOnLoad(this.gameObject);
        if(Active)
            this.gameObject.SetActive(!Active);
    }
}
