using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : GameEntity, IMove {

    int ScoreP1 = 0;
    int ScoreP2 = 0;
    float Speed = 10f;

    public void Move(string name)
    {
        int rand = Random.Range(0, 2);

        if (rand == 0)
        {
            GameObject.Find(name).GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, 0);
        }
        else
        {
            GameObject.Find(name).GetComponent<Rigidbody2D>().velocity = new Vector2(-Speed, 0);
        }
        
    }

    private void OnBecameInvisible()
    {
        if (this.transform.position.x > GameObject.Find("Main Camera").transform.localScale.x)
        {
            ScoreP1++;
            GameObject.Find("txtScoreP1").GetComponent<Text>().text = ScoreP1.ToString();
        }
        else if (this.transform.position.x < GameObject.Find("Main Camera").transform.localScale.x)
        {
            ScoreP2++;
            GameObject.Find("txtScoreP2").GetComponent<Text>().text = ScoreP2.ToString();
        }
        this.transform.position = new Vector3(0, 0, -1);
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        if (ScoreP1 == 5 || ScoreP2 == 5)
        {
            Speed = Speed * 2;
        }

        Move("Ball");
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

}
