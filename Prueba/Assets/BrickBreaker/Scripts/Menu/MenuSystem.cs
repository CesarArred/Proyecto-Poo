using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour {

    public void btnPlay()
    {
        SceneManager.LoadScene("Level1");
    }

    public void btnScore()
    {
        SceneManager.LoadScene("Scores");
    }

	public void btnBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void btnBackMenu()
    {
        SceneManager.LoadScene("MenuBrickBreaker");
    }


    
    
}
