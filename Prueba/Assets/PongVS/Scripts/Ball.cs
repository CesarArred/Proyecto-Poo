using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : GameEntity, IMove {

    public int ScoreP1 = 0;
    public int ScoreP2 = 0;
    float Speed = 5f;
    public int ballForce;
    public bool Finish = false;
    int Velcont = 1;

    private void Update()
    {
        if (Finish)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Restart();
            }
        }
    }

    public void Move(string name)
    {
        int rand = Random.Range(0, 2);
        int rand2 = Random.Range(0, 2);

        if (rand == 0 && rand2 == 0)
        {
            GameObject.Find(name).GetComponent<Rigidbody2D>().velocity = new Vector2(-Speed, Speed);
        }
        else if (rand == 0 && rand2 == 1)
        {
            GameObject.Find(name).GetComponent<Rigidbody2D>().velocity = new Vector2(-Speed, -Speed);
        }
        else if (rand == 1 && rand2 == 0)
        {
            GameObject.Find(name).GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, Speed);
        }
        else
        {
            GameObject.Find(name).GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, -Speed);
        }
        
    }

    private void OnBecameInvisible()
    {
        if (this.transform.position.x > GameObject.Find("Main Camera").transform.localScale.x)
        {
            ScoreP1++;
            if (Velcont == 6)
            {

            } else
            {
                Speed += 2;
            }
            Velcont++;
            GameObject.Find("txtScoreP1").GetComponent<Text>().text = ScoreP1.ToString();
        }
        else if (this.transform.position.x < GameObject.Find("Main Camera").transform.localScale.x)
        {
            ScoreP2++;
            if (Velcont == 6)
            {

            }
            else
            {
                Speed += 2;
            }
            Velcont++;
            GameObject.Find("txtScoreP2").GetComponent<Text>().text = ScoreP2.ToString();
        }
        this.transform.position = new Vector3(0, 0, -1);
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);


        if (ScoreP1 == 10)
        {
            GameObject.Find("txtWinner").GetComponent<Text>().text = "P1 WIN" + "\n" + "Press Space to restart or Esc to leave";
            Finish = true;
            Speed = 5f;
        }
        else if (ScoreP2 == 10)
        {
            GameObject.Find("txtWinner").GetComponent<Text>().text = "P2 WIN" + "\n" + "Press Space to restart or Esc to leave";
            Finish = true;
            Speed = 5f;
        }
        else
        {
            Move("Ball");
        }
    }

    private void OnCollisionEnter2D(Collision2D hit)
    {
        float Distance1 = this.transform.position.y - GameObject.Find("Player1").transform.position.y;
        float Distance2 = this.transform.position.y - GameObject.Find("Player2").transform.position.y;
        float velX = 5f;

        if (hit.gameObject.name == "Player1")
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(velX, Distance1 * Speed);
        }
        else if (hit.gameObject.name == "Player2")
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-velX, Distance2 * Speed);
        }
    }

    void Restart()
    {
        ScoreP1 = 0;
        ScoreP2 = 0;
        GameObject.Find("txtScoreP1").GetComponent<Text>().text = "0";
        GameObject.Find("txtScoreP2").GetComponent<Text>().text = "0";
        GameObject.Find("txtWinner").GetComponent<Text>().text = "";
        Finish = false;
        Move("Ball");
    }

}
