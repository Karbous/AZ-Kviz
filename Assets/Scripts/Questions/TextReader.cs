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
    [SerializeField] GameObject startGameButton;
    [HideInInspector] public string errorText;


    void Awake()
    {
        readPathMainQuestions = Application.dataPath + "/txt/hlavni_otazky.txt";
        readPathSubstituteQuestions = Application.dataPath + "/txt/nahradni_otazky.txt";
        ReadQuestionsTextFile(readPathMainQuestions, mainQuestionList);
        ReadQuestionsTextFile(readPathSubstituteQuestions, substituteQuestionList);
    }

    private void ReadQuestionsTextFile(string readPath, QuestionList questionList)
    {
        if (File.Exists(readPath))
        {
            StreamReader streamReader = new StreamReader(readPath);

            while (!streamReader.EndOfStream)
            {
                questionList.list.Add(streamReader.ReadLine());
            }
            streamReader.Close();
        }
        else
        {
            startGameButton.SetActive(false);
            error.SetActive(true);
            error.GetComponentInChildren<TextMeshProUGUI>().text += errorText + "\n" + readPath + "\n";
        }
    }
}
