using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class TempScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        TextReader Reade = new StreamReader("Score.txt");
        string Score = Reade.ReadLine();
        GameObject.Find("txtScore").GetComponent<Text>().text = Score;
        Reade.Close();
        File.Delete("Score.txt");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
