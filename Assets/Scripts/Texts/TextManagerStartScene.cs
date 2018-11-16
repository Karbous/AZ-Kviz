using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManagerStartScene : MonoBehaviour
{
    [SerializeField] LanguageSet languageSet;

    [SerializeField] TextMeshProUGUI quitGameButtonText;
    [SerializeField] TextMeshProUGUI startGameButtonText;
    [SerializeField] TextMeshProUGUI player1NameInputField;
    [SerializeField] TextMeshProUGUI player2NameInputField;
    [SerializeField] TextReader textReader;

    Language currentLanguage;

    private void Awake()
    {
        currentLanguage = languageSet.currentLanguage;

        quitGameButtonText.text = currentLanguage.quit;
        startGameButtonText.text = currentLanguage.startGame;
        player1NameInputField.text = currentLanguage.player1Name;
        player2NameInputField.text = currentLanguage.player2Name;
        textReader.errorText = currentLanguage.errorText;
    }
}
