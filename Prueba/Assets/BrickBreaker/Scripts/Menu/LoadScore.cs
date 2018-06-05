using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LoadScore : MonoBehaviour {
    int Page = 1;

	// Use this for initialization
	void Start () {
        TextReader ReadeScore = new StreamReader("BestScore.txt");
        TextReader ReadePlayer = new StreamReader("Players.txt");
        for (int cont = 0; cont < 10; cont++)
        {
            string value = ReadePlayer.ReadLine();
            Debug.Log(value);
            GameObject.Find("txtUsers").GetComponent<Text>().text += "\r\n" + (cont + 1).ToString() + ". " + value;
            value = ReadeScore.ReadLine();
            Debug.Log(value);
            GameObject.Find("txtScores").GetComponent<Text>().text += "\r\n" + value;
        }
        ReadePlayer.Close();
        ReadeScore.Close();
    }
	
	// Update is called once per frame
	public void NextPage()
    {
        TextReader ReadeScore = new StreamReader("BestScore.txt");
        TextReader ReadePlayer = new StreamReader("Players.txt");
        GameObject.Find("txtUsers").GetComponent<Text>().text = "Users";
        GameObject.Find("txtScores").GetComponent<Text>().text = "Score";

        for (int cont  = Page * 10; cont > 0; cont--)
        {
            ReadePlayer.ReadLine();
            ReadeScore.ReadLine();
        }

        for(int cont = Page * 10; cont < ((Page + 1) * 10); cont++)
        {
            string value = ReadePlayer.ReadLine();
            Debug.Log(value);
            GameObject.Find("txtUsers").GetComponent<Text>().text += "\r\n" + (cont + 1).ToString() + ". " + value;
            value = ReadeScore.ReadLine();
            Debug.Log(value);
            GameObject.Find("txtScores").GetComponent<Text>().text += "\r\n" + value;
        }

        Page++;
        ReadePlayer.Close();
        ReadeScore.Close();
    }

    public void BackPage()
    {
        if (Page == 1)
        {
        }
        else
        {
            TextReader ReadeScore = new StreamReader("BestScore.txt");
            TextReader ReadePlayer = new StreamReader("Players.txt");
            GameObject.Find("txtUsers").GetComponent<Text>().text = "Users";
            GameObject.Find("txtScores").GetComponent<Text>().text = "Score";
            if (Page == 2)
            {
                for (int cont = 0; cont < 10; cont++)
                {
                    string value = ReadePlayer.ReadLine();
                    Debug.Log(value);
                    GameObject.Find("txtUsers").GetComponent<Text>().text += "\r\n" + (cont + 1).ToString() + ". " + value;
                    value = ReadeScore.ReadLine();
                    Debug.Log(value);
                    GameObject.Find("txtScores").GetComponent<Text>().text += "\r\n" + value;
                }
                Page--;
            }
            else
            {
                int val = Page - 2;
                for (int cont = val * 10; cont > 0; cont--)
                {
                    ReadePlayer.ReadLine();
                    ReadeScore.ReadLine();
                }

                for (int cont = val * 10; cont < ((val + 1) * 10); cont++)
                {
                    string value = ReadePlayer.ReadLine();
                    Debug.Log(value);
                    GameObject.Find("txtUsers").GetComponent<Text>().text += "\r\n" + (cont + 1).ToString() + ". " + value;
                    value = ReadeScore.ReadLine();
                    Debug.Log(value);
                    GameObject.Find("txtScores").GetComponent<Text>().text += "\r\n" + value;
                }
                Page--;
            }
            
            ReadePlayer.Close();
            ReadeScore.Close();
        }  
    }
}
