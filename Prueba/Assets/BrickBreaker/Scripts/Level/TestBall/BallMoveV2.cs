using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoveV2 : MonoBehaviour
{
    bool Ready = false;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        OnCollisionBar();

        if (StartMove())
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D hit)
    {
        float distance = this.transform.position.x - GameObject.Find("Bar").transform.position.x;
        print(distance);


    }

    bool StartMove()
    {
        bool Start = false;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Start = true;
        }
        return Start;
    }

    void OnCollisionBar()
    {
        if (this.transform.position.y == -2.678535)
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 0;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        }
    } 

}
