using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class TextReader : MonoBehaviour
{
    string readPathMainQuestions;
    string readPathSubstituteQuestions;

    [SerializeField] QuestionList mainQuestionList;
    [SerializeField] QuestionList substituteQuestionList;
    [SerializeField] GameObject error;
    [SerializeField] TextMeshProUGUI errorTextUI;
    [SerializeField] GameObject startGameButton;
    [HideInInspector] public string errorText;


    void Start()
    {
        mainQuestionList.list.Clear();
        substituteQuestionList.list.Clear();
        readPathMainQuestions = Application.dataPath + "/otazky/hlavni_otazky.txt";
        readPathSubstituteQuestions = Application.dataPath + "/otazky/nahradni_otazky.txt";
        ReadQuestionsTextFile(readPathMainQuestions, mainQuestionList);
        ReadQuestionsTextFile(readPathSubstituteQuestions, substituteQuestionList);
    }

    private void ReadQuestionsTextFile(string readPath, QuestionList questionList)
    {
        if (File.Exists(readPath))
        {
            StreamReader streamReader = new StreamReader(readPath, System.Text.Encoding.Unicode);

            while (!streamReader.EndOfStream)
            {
                string newQuestion = streamReader.ReadLine();
                newQuestion.Trim();
                if (newQuestion.Length > 0 && newQuestion[0] != '*')
                {
                    questionList.list.Add(newQuestion);
                }
            }
            streamReader.Close();
        }
        else
        {
            startGameButton.SetActive(false);
            error.SetActive(true);
            errorTextUI.text += errorText + "\n" + readPath + "\n";
        }
    }
}
