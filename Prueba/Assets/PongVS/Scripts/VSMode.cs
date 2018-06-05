using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VSMode : MonoBehaviour {

    Player P1 = new Player(0,KeyCode.W, KeyCode.S);
    Player P2 = new Player(0,KeyCode.UpArrow,KeyCode.DownArrow);
    Ball B1 = new Ball();
    bool Ingame = false;

	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    private void Update()
    {
        if (Ingame)
        {

        }
        else
        {
            BallMove();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuPong");
        }

    }

    void FixedUpdate () {
        P1Move();
        P2Move();
    }

    void P1Move()
    {
        P1.Move("Player1");
    }

    void P2Move()
    {
        P2.Move("Player2");
    }
    
    void BallMove()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            B1.Move("Ball");
            Ingame = true;
        }
    }
}
