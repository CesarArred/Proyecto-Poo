using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
        File.Delete("Score.txt");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
