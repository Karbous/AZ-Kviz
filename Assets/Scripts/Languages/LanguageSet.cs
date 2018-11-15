using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Language Set")]
public class LanguageSet : ScriptableObject
{
    public Language[] languageSet;
    public Language currentLanguage;

    public void SetCurrentLanguage(int index)
    {
        currentLanguage = languageSet[index];
    }
}
