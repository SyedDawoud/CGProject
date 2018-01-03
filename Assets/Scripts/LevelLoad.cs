using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoad : MonoBehaviour {

	public void changeLevel()
    {
        SceneManager.LoadScene("main");
        
    }

    public void charSelect()
    {
        SceneManager.LoadScene("Select");
    }

    public void KJSelect() {

        CharacterSelection.char_choice = 1;
        SceneManager.LoadScene("main");
    }

    public void DSSelect()
    {
        
        CharacterSelection.char_choice = 2;
        SceneManager.LoadScene("main");
    }

    public void exitGame()
    {
        Debug.Log("Exit called");
        Application.Quit();
    }
}
