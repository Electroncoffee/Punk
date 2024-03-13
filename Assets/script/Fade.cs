using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public static Fade instance;
    [SerializeField]
    CanvasRenderer canvasRenderer;
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
    void Start()
    {
        canvasRenderer.SetAlpha(0);
    }
    public void Transition(float delay=0.1f, float speed=1f)
    {
        StartCoroutine(Fade_IO(speed,delay));
    }
    public void Transition_In(float speed = 1f)
    {
        StartCoroutine(Fade_In(speed));
    }
    public void Transition_Out(float speed = 1f)
    {
        StartCoroutine(Fade_Out(speed));
    }
    IEnumerator Fade_IO(float speed, float delay)
    {
        canvasRenderer.gameObject.SetActive(true);
        for (float i = 0; i <= 1; i += Time.deltaTime * speed)
        {
            canvasRenderer.SetAlpha(i);
            yield return null;
        }
        yield return new WaitForSeconds(delay);
        for (float i = 1; i >= 0; i -= Time.deltaTime * speed)
        {
            canvasRenderer.SetAlpha(i);
            yield return null;
        }
        canvasRenderer.gameObject.SetActive(false);
    }
    IEnumerator Fade_In(float speed)
    {
        canvasRenderer.gameObject.SetActive(true);
        for (float i = 0; i <= 1; i += Time.deltaTime * speed)
        {
            canvasRenderer.SetAlpha(i);
            yield return null;
        }
    }
    IEnumerator Fade_Out(float speed)
    {
        for (float i = 1; i >= 0; i -= Time.deltaTime * speed)
        {
            canvasRenderer.SetAlpha(i);
            yield return null;
        }
        canvasRenderer.gameObject.SetActive(false);
    }
}
