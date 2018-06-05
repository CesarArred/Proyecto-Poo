using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class BrickBreaker : MonoBehaviour {

    BallBB Nball = new BallBB();
    Player1 P1 = new Player1();
    bool Pause = false;

	// Use this for initialization
	void Start () {
        int rand = Random.Range(0, 4);
        switch (rand)
        {
            case 0:
                GameObject.Find("Stage").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Stage/Tournament");
                GameObject.Find("Stage").transform.localScale = new Vector3(1.481767f, 1.443699f, 1f);
                GameObject.Find("Stage").transform.position = new Vector3(-0.012f, -0.053f, 10f);
                break;

            case 1:
                GameObject.Find("Stage").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Stage/Namek");
                GameObject.Find("Stage").transform.localScale = new Vector3(0.9273499f, 0.9238058f, 1f);
                GameObject.Find("Stage").transform.position = new Vector3(-0.012f, -0.053f, 10f);
                break;

            case 2:
                GameObject.Find("Stage").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Stage/Mountains");
                GameObject.Find("Stage").transform.localScale = new Vector3(0.9273499f, 0.9238058f, 1f);
                GameObject.Find("Stage").transform.position = new Vector3(-0.012f, 0.006f, 10f);
                break;

            case 3:
                GameObject.Find("Stage").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Stage/GokusHouse");
                GameObject.Find("Stage").transform.localScale = new Vector3(1.738398f, 1.733015f, 1f);
                GameObject.Find("Stage").transform.position = new Vector3(0.03f, 0.048f, 10f);
                break;
        }

        int generatelife = Random.Range(1, 4);
        if (generatelife == 3)
        {
            int rand2 = Random.Range(0, 49);
            string CapsuleID = "C" + rand2.ToString();
            GameObject.Find(CapsuleID).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("BBObjects/CGolden");
            Vector3 PositionC = GameObject.Find(CapsuleID).transform.position;
            GameObject.Find("Particles").transform.position = PositionC;
            GameObject.Find(CapsuleID).tag = "LifeBrick";
            BombsGenerate(rand2);
        }
        else
        {
            BombsGenerate(-1);
        }

        float posx = ((GameObject.Find("Bar").transform.position.x + GameObject.Find("Bar").transform.localScale.y) / 2) - GameObject.Find("Ball").transform.localScale.x;
        float posy = GameObject.Find("Bar").transform.position.y + GameObject.Find("Bar").transform.localScale.y;
        GameObject.Find("Ball").transform.position = new Vector3(posx, posy, -1);
        GameObject.Find("txtLifes").GetComponent<Text>().text = "Lives: 3";
        GameObject.Find("txtStart").GetComponent<Text>().text = "Press space to start";

        if (File.Exists("Score.txt"))
        {
            TextReader Reade = new StreamReader("Score.txt");
            string PScore = Reade.ReadLine();
            if (PScore == "")
            {
                GameObject.Find("txtScore").GetComponent<Text>().text = "Score: " + Nball.Score;
            }
            else
            {
                GameObject.Find("txtScore").GetComponent<Text>().text = "Score: " + PScore;
                GameObject.Find("Ball").GetComponent<BallBB>().Score = int.Parse(PScore);
            }
            Reade.Close();
            File.Delete("Score.txt");
        }
        else
        {
            GameObject.Find("txtScore").GetComponent<Text>().text = "Score: " + Nball.Score;
        }
        
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        P1.Move("Bar");
        P1.Big.PBIg("Bar");
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuBrickBreaker");
        }
    }

    void BombsGenerate(int pos)
    {
        bool finish = false;
        int cont = 0;
        int posB1 = -1;
        int posB2 = -1;
        while(finish == false)
        {
            int rand2 = Random.Range(0, 49);
            if (rand2 == pos || rand2 == posB1 || rand2 == posB2)
            {

            }
            else
            {
                string CapsuleID = "C" + rand2.ToString();
                GameObject.Find(CapsuleID).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("BBObjects/CBronze");
                GameObject.Find(CapsuleID).tag = "BombBrick";
                cont++;
                switch (cont)
                {
                    case 1:
                        posB1 = rand2;
                        break;
                    case 2:
                        posB2 = rand2;
                        break;
                }
            }

            if (cont == 3)
            {
                finish = true;
            }
        }
    }
}
