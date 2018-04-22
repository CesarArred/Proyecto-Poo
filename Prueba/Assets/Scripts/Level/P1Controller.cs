using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Controller : MonoBehaviour {

    public KeyCode MoveLeft;
    public KeyCode MoveRigth;
    public float Speed;
	
	private void FixedUpdate () {
		
        if (Input.GetKey(MoveLeft))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-Speed,0);
        }
        else if (Input.GetKey(MoveRigth))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, 0);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

    }
}
