using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endGameScore : MonoBehaviour {


    public Text text;

    public Text text1;

    private void Start()
    {
        text.text ="Score : " + CharacterSelection.accessible_score.ToString();
        text1.text = "HighScore : " + CharacterSelection.highScore.ToString();
    }
}
