using UnityEngine;
using UnityEngine.UI;
public enum GameLanguage { ENGLISH, KOREAN }
public class LanguageManager : MonoBehaviour
{
    public GameLanguage setlanguage;
    [SerializeField]
    Dropdown dropdown;
    private void Awake()
    {
        if (Application.systemLanguage == SystemLanguage.English)
        {
            setlanguage = GameLanguage.ENGLISH;
        }
        else if(Application.systemLanguage == SystemLanguage.Korean)
        {
            setlanguage = GameLanguage.KOREAN;
        }
        else
            setlanguage = GameLanguage.ENGLISH;
        dropdown.value = (int)setlanguage;
        Debug.Log("Language Set Completed :" + setlanguage);
    }
    public void Set_language()
    {
        if (dropdown.value == (int)GameLanguage.ENGLISH)
        {
            setlanguage = GameLanguage.ENGLISH;
        }
        else if (dropdown.value == (int)GameLanguage.KOREAN)
        {
            setlanguage = GameLanguage.KOREAN;
        }
        else
        {
            Debug.Log("잘못된 인수 입력됨");
        }
        Debug.Log("Language Set Completed :" + setlanguage);
    }
}
