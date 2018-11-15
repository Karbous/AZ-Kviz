using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManagerGameScene : MonoBehaviour
{
    [SerializeField] LanguageSet languageSet;

    [SerializeField] TextMeshProUGUI playAgainButtonText;
    [SerializeField] TextMeshProUGUI quitButtonText;
    [SerializeField] GameEnd gameEnd;

    Language currentLanguage;

    private void Awake()
    {
        currentLanguage = languageSet.currentLanguage;
        playAgainButtonText.text = currentLanguage.playAgain;
        quitButtonText.text = currentLanguage.quit;
        gameEnd.theWinnerIs = currentLanguage.theWinnerIs;
    }
}
