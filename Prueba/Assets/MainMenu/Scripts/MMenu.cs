using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MMenu : MonoBehaviour {

    public void btnBrickBreaker()
    {
        SceneManager.LoadScene("MenuBrickBreaker");
    }

    public void btnPlayVs()
    {
        SceneManager.LoadScene("MenuPong");
    }

    public void btnExit()
    {
        Application.Quit();
    }
}
