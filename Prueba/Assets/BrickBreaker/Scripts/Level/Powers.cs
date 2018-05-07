using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : GameEntity {

    bool PowerOn = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void PBIg (string name) {
        if (PowerOn)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                float ScaleY = GameObject.Find(name).transform.localScale.y;
                GameObject.Find(name).transform.localScale = new Vector3(0.2539444f, ScaleY, 1f);
                PowerOn = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                float ScaleX = GameObject.Find(name).transform.localScale.x;
                float ScaleY = GameObject.Find(name).transform.localScale.y;
                GameObject.Find(name).transform.localScale = new Vector3(ScaleX + ScaleX, ScaleY, 1f);
                PowerOn = true;
            }
        }

	}
}
