using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {

	// Use this for initialization
	void Start () {

        
        int rand = Random.Range(0, 2);

        if (rand == 0)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5f);
        } else if (rand == 1)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5f);
        } 
       
	}

	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D hit)
    {
        float distance = this.transform.position.x - GameObject.Find("Bar").transform.position.x;
        print(distance);


    }
}
