using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickBreaker : MonoBehaviour {

    Player1 P1 = new Player1();
    bool Keyready = false;

	// Use this for initialization
	void Start () {
        float posx = ((GameObject.Find("Bar").transform.position.x + GameObject.Find("Bar").transform.localScale.y) / 2) - GameObject.Find("Ball").transform.localScale.x;
        float posy = GameObject.Find("Bar").transform.position.y + GameObject.Find("Bar").transform.localScale.y;
        GameObject.Find("Ball").transform.position = new Vector3(posx, posy, -1);
        GameObject.Find("txtLifes").GetComponent<Text>().text = "Lifes: 3";
        GameObject.Find("txtStart").GetComponent<Text>().text = "Press space to start";
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        P1.Move("Bar");
        P1.Big.PBIg("Bar");
	}

 
}
