using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bricks : MonoBehaviour {
    
    

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Ball")
        {
            Object.Destroy(gameObject);
            //BrickAnim.SetBool("BrickHit", true);
        }

        
    }
}
