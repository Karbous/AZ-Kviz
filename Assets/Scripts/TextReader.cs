using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TextReader : MonoBehaviour
{
    string readPathMainQuestions;
    string readPathSubstituteQuestions;

    [SerializeField] QuestionList mainQuestionList;
    [SerializeField] QuestionList substituteQuestionList;
    [SerializeField] Text errorText;
    [SerializeField] GameObject introCanvas;


    void Awake()
    {
        readPathMainQuestions = Application.dataPath + "/txt/questions.txt";
        readPathSubstituteQuestions = Application.dataPath + "/txt/substitute_questions.txt";
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
            introCanvas.SetActive(false);
            errorText.text = "The text file with questions is missing!";
        }
    }
}
