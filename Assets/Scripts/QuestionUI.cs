using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI activePlayerText;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] GameObject correctButton;
    [SerializeField] GameObject wrongButton;
    [SerializeField] GameObject notAnsweredButton;
    [SerializeField] Timer timer;

    [SerializeField] QuestionList mainQuestionList;
    [SerializeField] QuestionList substituteQuestionList;

    [HideInInspector] public string noMoreQuestions;

    public void DisplayNewQuestion(int tileState)
    {
        DisplayCorrectWrongButtons();
        DisplayQuestionText(tileState);
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
    public void DisplayActivePlayer(Player activePlayer)
    {
        activePlayerText.text = activePlayer.Name;
        activePlayerText.color = activePlayer.Color;
    }

    private void ClearQuestionText()
    {
        questionText.text = "";
    }

    private void DisplayQuestionText(int tileState)
    {
        QuestionList currentQuestionList;
        if (tileState == -1)
        {
            currentQuestionList = mainQuestionList;
        }
        else
        {
            currentQuestionList = substituteQuestionList;
        }


        if (currentQuestionList.list.Count > 0)
        {
            timer.StartTimer();
            questionText.text = currentQuestionList.list[0];
            currentQuestionList.list.RemoveAt(0);
        }
        else
        {
            timer.StopTimer();
            HideAllButtons();
            questionText.text = noMoreQuestions;
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