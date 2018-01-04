using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayer : MonoBehaviour {

    [SerializeField]
    public Text text; 
	// Use this for initialization
	void Start () {
        string temp = System.IO.File.ReadAllText("Assets/Scripts/highscore.txt");
        text.text = "HighScore : " + temp;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
