using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : GameEntity, IMove {

    public float Speed = 5f;
    public Powers Big = new Powers();

    public void Move(string name) {
		
        if (Input.GetKey(KeyCode.A))
        {
            GameObject.Find(name).GetComponent<Rigidbody2D>().velocity = new Vector2(-Speed,0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            GameObject.Find(name).GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, 0);
        }
        else
        {
            GameObject.Find(name).GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

    }
}
