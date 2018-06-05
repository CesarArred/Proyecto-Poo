using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystemVs : MonoBehaviour {

    public void btnBackMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void btnP1VSP2()
    {
        SceneManager.LoadScene("LevelVS");
    }

    public void btnVshelp()
    {
        SceneManager.LoadScene("VSHelp");
    }
}
