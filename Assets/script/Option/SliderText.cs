using UnityEngine;
using UnityEngine.UI;

public class SliderText : MonoBehaviour
{
    [SerializeField]
    Slider slider;
    [SerializeField]
    Text text;
    public void substituteText()
    {
        int volume = (int)(slider.value * 100);
        text.text = volume.ToString() + '%';
    }
}
