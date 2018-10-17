using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseQuestion : MonoBehaviour
{
    [SerializeField] DisplayQuestion displayQuestion;
    
    private void OnMouseDown()
    {
        if(GetComponent<TileState>().tileState == -1)
        {
            displayQuestion.DisplayNewQuestion();
        }
    }
}
