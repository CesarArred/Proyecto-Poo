using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBar : MonoBehaviour {

    public bool Move = false;
    public bool Crash = false;
    public KeyCode MoveLeft;
    public KeyCode MoveRight;
    public float Jump;
    

    private void FixedUpdate()
    {
        Initialize();
        //Collision();

        if (Move == true && Crash == false)
        {
           
            if (Input.GetKeyDown(MoveLeft))
            {
                this.transform.position += new Vector3(-1f, 0, 0);
            }
            else if (Input.GetKeyDown(MoveRight))
            {
                this.transform.position += new Vector3(1f, 0, 0);
            }           
        }
        else
        {

        }
    }

    void Initialize()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Move = true;
        }
        else
        {

        }
    }

    void Collision()
    {
       double X = GetComponent<Transform>().position.x;

        if (X <= -7.6 || X >= 7.6)
        {
            Crash = true;
        }
        else
        {
            Crash = false;
        }
    }

}
