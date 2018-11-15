using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Language")]
public class Language : ScriptableObject
{
    public string newGame;
    public string quit;
    public string startGame;
    public string player1Name;
    public string player2Name;
    public string errorText;
    public string playAgain;
    public string theWinnerIs;
}
