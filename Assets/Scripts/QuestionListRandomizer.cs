using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionListRandomizer : MonoBehaviour
{
    [SerializeField] QuestionList mainQuestionList;
    List<string> originalList = new List<string>();
    List<string> shuffledList = new List<string>();

    void Start()
    {
        originalList = mainQuestionList.list;

        while (originalList.Count > 0)
        {
            int randomIndex = Random.Range(0, originalList.Count);
            shuffledList.Add(originalList[randomIndex]);
            originalList.RemoveAt(randomIndex);
        }
        mainQuestionList.list = shuffledList;
    }
	
}
