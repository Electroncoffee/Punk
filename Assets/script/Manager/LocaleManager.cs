using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleManager : MonoBehaviour
{
    bool ischanging;
    public void ChangeLocale(int index)
    {
        if (ischanging)
        {
            return;
        }
        StartCoroutine(ChangeRoutine(index));
    }
    IEnumerator ChangeRoutine(int index)
    {
        ischanging = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
        ischanging= false;
    }
}
