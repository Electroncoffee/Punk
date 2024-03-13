using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Instance : MonoBehaviour
{
    public static Dialogue_Instance instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
