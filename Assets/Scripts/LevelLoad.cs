using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoad : MonoBehaviour {

	public void changeLevel()
    {
        SceneManager.LoadScene("main");
        
    }

    public void exitGame()
    {
        Debug.Log("Exit called");
        Application.Quit();
    }
}
