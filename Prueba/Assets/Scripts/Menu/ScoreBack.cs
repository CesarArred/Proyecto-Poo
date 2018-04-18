using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreBack : MonoBehaviour {

	public void btnBack()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("De vuelta al menu");
    }
}
