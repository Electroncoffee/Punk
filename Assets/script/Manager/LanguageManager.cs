using UnityEngine;
public enum GameLanguage { ENGLISH, KOREAN }
public class LanguageManager : MonoBehaviour
{
    public GameLanguage setlanguage;
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
        Debug.Log("Language Set Completed :" + setlanguage);
    }
    public void Set_language(int Inputlanguage)
    {
        if (Inputlanguage == (int)GameLanguage.ENGLISH)
        {
            setlanguage = GameLanguage.ENGLISH;
        }
        else if (Inputlanguage == (int)GameLanguage.KOREAN)
        {
            setlanguage = GameLanguage.KOREAN;
        }
        else
        {
            setlanguage = GameLanguage.ENGLISH;
            Debug.Log("잘못된 인수 입력됨");
        }
        Debug.Log("Language Set Completed :" + setlanguage);
    }
}
