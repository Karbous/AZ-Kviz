using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Question List")]
public class QuestionList: ScriptableObject
{
    public List<string> list = new List<string>();
}
