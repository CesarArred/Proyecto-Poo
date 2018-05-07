using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BallBB : GameEntity {

    bool game = false;
    int lifes = 3;
    bool keyReady;
    float rebound = 2;
    bool Ingame = false;
    int contBricks = 48;
    Animator BrickAnim;

    // Use this for initialization
    void Start() {
        
        BrickAnim = GetComponent<Animator>();

    }

	// Update is called once per frame
	void Update () {
        if (Ingame)
        {
            if (contBricks == 0)
            {
                SceneManager.LoadScene("MenuBrickBreaker");
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5f);
                Ingame = true;
                GameObject.Find("txtStart").GetComponent<Text>().text = "";
            } else
            {
                float PosX = GameObject.Find("Bar").transform.position.x;
                float PosY = GameObject.Find("Bar").transform.position.y + GameObject.Find("Bar").transform.localScale.y;

                this.transform.position = new Vector3(PosX,PosY,-1);
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D hit)
    {
        float distance = this.transform.position.x - GameObject.Find("Bar").transform.position.x;
        Rigidbody2D BBall = GetComponent<Rigidbody2D>();
        float velX = gameObject.GetComponent<Rigidbody2D>().velocity.x;
        Debug.Log(velX);
        float velY = 5f;


        switch (hit.gameObject.name)
        {
            case "Bar":
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(distance * 2f, velY);
                break;

            case "Roof":
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(velX, -velY);
                break;
        }

        if (hit.gameObject.tag == "Brick")
        {
            Object.Destroy(hit.gameObject, 0.3f);
            //BrickAnim.SetBool("BrickHit", true);
            contBricks--;
        }

    }

    private void OnBecameInvisible()
    {
        if (lifes == 1)
        {
            SceneManager.LoadScene("GameOverBB");
        } else
        {
            lifes--;
            GameObject.Find("txtLifes").GetComponent<Text>().text = "Lifes: " + lifes.ToString();
            GameObject.Find("Bar").transform.position = new Vector3(0.035f, -4.5f, -1);
            float posx = ((GameObject.Find("Bar").transform.position.x + GameObject.Find("Bar").transform.localScale.y) / 2) - this.transform.localScale.x;
            float posy = GameObject.Find("Bar").transform.position.y + GameObject.Find("Bar").transform.localScale.y;
            transform.position = new Vector3(posx, posy, -1);
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Ingame = false;
            GameObject.Find("txtStart").GetComponent<Text>().text = "Press space to start";

        }
    }
}
