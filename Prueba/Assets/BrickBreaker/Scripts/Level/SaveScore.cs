using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveScore : MonoBehaviour {

    public void SavePlayerScore()
    {
        StreamWriter WriteScore = File.AppendText("BestScore.txt");
        StreamWriter WriteName = File.AppendText("Players.txt");
        string Name = GameObject.Find("PlayerName").GetComponent<InputField>().text;
        if (Name == "")
        {
            GameObject.Find("Error").GetComponent<RectTransform>().position = new Vector3(0, 0, -1);
        }
        else
        {
            string Score = GameObject.Find("txtScore").GetComponent<Text>().text;
            WriteScore.WriteLine(Score);
            WriteName.WriteLine(Name);
            SceneManager.LoadScene("MenuBrickBreaker");
        }
        WriteScore.Close();
        WriteName.Close();
    }
    
    public void Continue()
    {
        GameObject.Find("SureMessage").GetComponent<RectTransform>().position = new Vector3(0, 0, -1);   
    }

    public void OK()
    {
        GameObject.Find("Error").GetComponent<RectTransform>().position = new Vector3(0, 0, 300);
    }

    public void YesClick()
    {
        string Score = GameObject.Find("txtScore").GetComponent<Text>().text;
        StreamWriter Write = File.AppendText("Score.txt");
        Write.WriteLine(Score);
        Write.Close();
        SceneManager.LoadScene("Level1");
    }

    public void NoClick()
    {
        GameObject.Find("SureMessage").GetComponent<RectTransform>().position = new Vector3(0, 0, 300);
    }
}
