using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class path : MonoBehaviour {

    //Rail thing
    public GameObject Left;
    public GameObject Right;
    public GameObject Middle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = this.transform.position;
        pos.z += (float)0.1;
        this.transform.position = pos;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(this.transform.position.x == Middle.transform.position.x)
            {
                Vector3 position = this.transform.position;
                position.x = Right.transform.position.x;
                this.transform.position = position;
            }
            else if(this.transform.position.x == Left.transform.position.x)
            {
                Vector3 position = this.transform.position;
                position.x = Middle.transform.position.x;
                this.transform.position = position;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(this.transform.position.x == Middle.transform.position.x)
            {
                Vector3 position = this.transform.position;
                position.x = Left.transform.position.x;
                this.transform.position = position;
            }
            else if(this.transform.position.x == Right.transform.position.x)
            {
                Vector3 position = this.transform.position;
                position.x = Middle.transform.position.x;
                this.transform.position = position;
            }
        }
	}
}
