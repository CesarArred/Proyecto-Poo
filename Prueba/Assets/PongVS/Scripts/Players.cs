using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : GameEntity, IMove {

    public KeyCode MoveUp;
    public KeyCode MoveDown;
    float Speed = 5f;

    private void Update()
    {
        int ScoreP1 = int.Parse(GameObject.Find("txtScoreP1").GetComponent<Text>().text);
        int ScoreP2 = int.Parse(GameObject.Find("txtScoreP2").GetComponent<Text>().text);

        if (ScoreP1 == 5 || ScoreP2 == 5)
        {
            Speed = Speed * 2;
        }

        
    }

    public Player(int points, KeyCode moveup, KeyCode movedown)
    {
        this.Points = points;
        this.MoveUp = moveup;
        this.MoveDown = movedown;
    }

    public void Move(string name)
    {
        if (Input.GetKey(MoveUp))
        {
            GameObject.Find(name).GetComponent<Rigidbody2D>().velocity = new Vector2(0, Speed);
        }
        else if (Input.GetKey(MoveDown))
        {
            GameObject.Find(name).GetComponent<Rigidbody2D>().velocity = new Vector2(0, -Speed);
        } else
        {
            GameObject.Find(name).GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}
