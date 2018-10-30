using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TextReader : MonoBehaviour
{
    string readPath;
    [SerializeField] QuestionList mainQuestionList;
    [SerializeField] int minNumberOfQuestions = 5;
    [SerializeField] Text errorText;
    [SerializeField] GameObject introCanvas;


    void Awake()
    {
        readPath = "C:/txt/questions.txt";
        ReadQuestionsTextFile(readPath);
        CheckNumberOfQuestions();
	}

    private void ReadQuestionsTextFile(string readPath)
    {
        if (File.Exists(readPath))
        {
            StreamReader streamReader = new StreamReader(readPath);

            while (!streamReader.EndOfStream)
            {
                mainQuestionList.list.Add(streamReader.ReadLine());
            }
            streamReader.Close();
        }
        else
        {
            introCanvas.SetActive(false);
            errorText.text = "The text file with questions is missing!";
        }
    }

    private void CheckNumberOfQuestions()
    {
        if (mainQuestionList.list.Count < minNumberOfQuestions)
        {
            introCanvas.SetActive(false);
            errorText.text = "The number of questions in text file is too low!";
        }
    }

}
