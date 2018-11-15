using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLanguage : MonoBehaviour
{
    [SerializeField] LanguageSet languageSet;

    public void SelectSpanish()
    {
        languageSet.SetCurrentLanguage(0);
    }

    public void SelectCzech()
    {
        languageSet.SetCurrentLanguage(1);
    }

    public void SelectEnglish()
    {
        languageSet.SetCurrentLanguage(2);
    }
}
