using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour {

    public void btnPlay()
    {
        SceneManager.LoadScene("Level1");
        Debug.Log("cambio de ecena");
    }

    public void btnScore()
    {
        SceneManager.LoadScene("Scores");
        Debug.Log("A ver el score");
    }

	public void btnExit()
    {
        Application.Quit();
        Debug.Log("Salir");
    }



    
    
}
