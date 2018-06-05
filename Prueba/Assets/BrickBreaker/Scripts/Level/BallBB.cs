using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;


public class BallBB : GameEntity {

    public bool GameFinish = false;
    int lifes = 3;
    float rebound = 2;
    bool Ingame = false;
    public Rigidbody2D rb;
    public float ballForce;
    public int Score = 0;
    int ContBricks = 48;
    bool UP = false;

    // Use this for initialization
    void Start() {

    }

	// Update is called once per frame
	void Update () {
        if (Ingame)
        {
            if (ContBricks == 0)
            {
                GameObject.Find("txtStart").GetComponent<Text>().text = "Complete \r   Loading...";
                SavePScore();
                SceneManager.LoadScene("GameFinish");
            }

            float velY = gameObject.GetComponent<Rigidbody2D>().velocity.y;

            if (velY < 0)
            {
                UP = false;
            } 
            else if (velY > 0)
            {
                UP = true;
            }
            else
            {
                float velX = gameObject.GetComponent<Rigidbody2D>().velocity.x;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velX, 20f);
            }
            BallVelocityY();

        } else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                int rand = Random.Range(-1, 2);
                rb.AddForce(new Vector2(ballForce * rand, ballForce));
                Ingame = true;
                GameObject.Find("txtStart").GetComponent<Text>().text = "";
                UP = true;
            }
            else
            {
                float PosX = GameObject.Find("Bar").transform.position.x;
                float PosY = GameObject.Find("Bar").transform.position.y + GameObject.Find("Bar").transform.localScale.y;

                this.transform.position = new Vector3(PosX, PosY, -1);
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D hit)
    {
        switch (hit.gameObject.tag)
        {
            case "Brick":
                Score += 10;
                ContBricks--;
                break;

            case "LifeBrick":
                lifes++;
                GameObject.Find("txtLifes").GetComponent<Text>().text = "Lives: " + lifes.ToString();
                Score += 100;
                ContBricks--;
                GameObject.Find("Particles").transform.position = new Vector3(500, 0, 0);
                break;

            case "BombBrick":
                Score += 50;
                ContBricks--;
                //BombExplotion(hit.gameObject.name);
                break;

            case "Player":
                float dist = transform.position.x - hit.gameObject.transform.position.x;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(dist * 3f, 5f);
                break;
        }
        GameObject.Find("txtScore").GetComponent<Text>().text = "Score: " + Score.ToString();
    }

    private void OnBecameInvisible()
    {
        if (lifes == 1)
        {
            SceneManager.LoadScene("GameOverBB");
        } else
        {
            lifes--;
            GameObject.Find("txtLifes").GetComponent<Text>().text = "Lives: " + lifes.ToString();
            GameObject.Find("Bar").transform.position = new Vector3(0.035f, -4.5f, -1);
            float posx = ((GameObject.Find("Bar").transform.position.x + GameObject.Find("Bar").transform.localScale.y) / 2) - this.transform.localScale.x;
            float posy = GameObject.Find("Bar").transform.position.y + GameObject.Find("Bar").transform.localScale.y;
            transform.position = new Vector3(posx, posy, -1);
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Ingame = false;
            GameObject.Find("txtStart").GetComponent<Text>().text = "Press space to start";
            

        }
    }
       
    void BallVelocityY()
    {
        float velY = gameObject.GetComponent<Rigidbody2D>().velocity.y;
        float velX = gameObject.GetComponent<Rigidbody2D>().velocity.y;
        if (UP)
        {

        }
        else
        {
            if (velY > -0.5f)
            {
                velY -= 0.5f;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velX, velY);
            }
        }
    }

    void BombExplotion(string name)
    {
        string pos = name.Substring(1);
        int PosN = int.Parse(pos);
       if (PosN <= 11)
        {
            string name1 = "C" + (PosN - 1).ToString();
            string name2 = "C" + (PosN + 1).ToString();
            string name3 = "C" + (PosN + 12).ToString();
            string name4 = "C" + ((PosN - 1) + 12).ToString();
            string name5 = "C" + ((PosN + 1) + 12).ToString();

            Tags(name1);
            Tags(name2);
            Tags(name3);
            Tags(name4);
            Tags(name5);

            Object.Destroy(GameObject.Find(name1));
            Object.Destroy(GameObject.Find(name2));
            Object.Destroy(GameObject.Find(name3));
            Object.Destroy(GameObject.Find(name4));
            Object.Destroy(GameObject.Find(name5));
        }
        else if (PosN > 11 && PosN <= 35)
        {
            string name1 = "C" + (PosN - 1).ToString();
            string name2 = "C" + (PosN + 1).ToString();
            string name3 = "C" + (PosN + 12).ToString();
            string name4 = "C" + (PosN - 12).ToString();
            string name5 = "C" + ((PosN - 1) + 12).ToString();
            string name6 = "C" + ((PosN - 1) - 12).ToString();
            string name7 = "C" + ((PosN + 1) + 12).ToString();
            string name8 = "C" + ((PosN - 1) - 12).ToString();

            Tags(name1);
            Tags(name2);
            Tags(name3);
            Tags(name4);
            Tags(name5);
            Tags(name6);
            Tags(name7);
            Tags(name8);

            Object.Destroy(GameObject.Find(name1));
            Object.Destroy(GameObject.Find(name2));
            Object.Destroy(GameObject.Find(name3));
            Object.Destroy(GameObject.Find(name4));
            Object.Destroy(GameObject.Find(name5));
            Object.Destroy(GameObject.Find(name6));
            Object.Destroy(GameObject.Find(name7));
            Object.Destroy(GameObject.Find(name8));
        }
        else
        {
            string name1 = "C" + (PosN - 1).ToString();
            string name2 = "C" + (PosN + 1).ToString();
            string name4 = "C" + (PosN - 12).ToString();
            string name5 = "C" + ((PosN -1) - 12).ToString();
            string name6 = "C" + ((PosN +1) - 12).ToString();

            Tags(name1);
            Tags(name2);
            Tags(name4);
            Tags(name5);
            Tags(name6);

            Object.Destroy(GameObject.Find(name1));
            Object.Destroy(GameObject.Find(name2));
            Object.Destroy(GameObject.Find(name4));
            Object.Destroy(GameObject.Find(name5));
            Object.Destroy(GameObject.Find(name6));
        }
    }

    void Tags(string name)
    {
        var obh = GameObject.Find(name);
        string ObjectTag = GameObject.Find(name).gameObject.tag;
        Debug.Log(ObjectTag);
        switch (ObjectTag)
        {
            case "Brick":
                Score += 10;
                ContBricks--;
                break;
            case "LifeBrick":
                lifes++;
                GameObject.Find("txtLifes").GetComponent<Text>().text = "Lives: " + lifes.ToString();
                Score += 100;
                ContBricks--;
                break;
            case "BombBrick":
                Score += 50;
                ContBricks--;
                BombExplotion(name);
                break;
        }
    }

    void SavePScore()
    {
        StreamWriter Write = File.AppendText("Score.txt");
        Write.WriteLine(Score.ToString());
        Write.Close();
    }
}
