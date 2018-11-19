using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionListRandomizer : MonoBehaviour
{
    [SerializeField] QuestionList mainQuestionList;
    [SerializeField] QuestionList substituteQuestionList;

    void Start()
    {
        SuffleQuestions(mainQuestionList);
        SuffleQuestions(substituteQuestionList);
    }

    private void SuffleQuestions(QuestionList questionList)
    {
        List<string> originalList = new List<string>();
        List<string> shuffledList = new List<string>();
        originalList = questionList.list;

        while (originalList.Count > 0)
        {
            int randomIndex = Random.Range(0, originalList.Count);
            shuffledList.Add(originalList[randomIndex]);
            originalList.RemoveAt(randomIndex);
        }
        questionList.list = shuffledList;
    }
}
