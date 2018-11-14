using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionUI : MonoBehaviour
{
    [SerializeField] Text activePlayerText;
    [SerializeField] Text questionText;
    [SerializeField] GameObject correctButton;
    [SerializeField] GameObject wrongButton;
    [SerializeField] GameObject notAnsweredButton;

    [SerializeField] QuestionList mainQuestionList;

    public void DisplayNewQuestion()
    {
        DisplayCorrectWrongButtons();
        DisplayQuestionText();
    }

    public void CleanQuestion(Player activePlayer)
    {
        DisplayActivePlayer(activePlayer);
        HideAllButtons();
        ClearQuestionText();
    }

    public void QuestionForOtherPlayer(Player activePlayer)
    {
        DisplayActivePlayer(activePlayer);
        AddNotAnsweredButton();
    }

    #region text
    private void DisplayActivePlayer(Player activePlayer)
    {
        activePlayerText.text = activePlayer.Name;
        activePlayerText.color = activePlayer.Color;
    }

    private void ClearQuestionText()
    {
        questionText.text = "";
    }

    private void DisplayQuestionText()
    {
        if (mainQuestionList.list.Count > 0)
        {
            questionText.text = mainQuestionList.list[0];
            mainQuestionList.list.RemoveAt(0);
        }
        else
        {
            questionText.text = "There are no more questions!";
            //TO DO Option to quit game or load more questions(?)
        }
    }
    #endregion

    #region buttons
    private void DisplayCorrectWrongButtons()
    {
        correctButton.SetActive(true);
        wrongButton.SetActive(true);
    }


    private void AddNotAnsweredButton()
    {
        notAnsweredButton.SetActive(true);
    }


    private void HideAllButtons()
    {
        correctButton.SetActive(false);
        wrongButton.SetActive(false);
        notAnsweredButton.SetActive(false);
    }
    #endregion
}