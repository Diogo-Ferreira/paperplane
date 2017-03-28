using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class path : MonoBehaviour {

    //Rail thing
    public GameObject Left;
    public GameObject Right;
    public GameObject Middle;

    public bool floatup;

	// Use this for initialization
	void Start () {
        floatup = false;
	}
	
	// Update is called once per frame
	void Update () {
        //go to z axe
        Vector3 pos = this.transform.position;
        pos.z += (float)0.1;
        this.transform.position = pos;

        //floating
        if (floatup)
        {
            floatingup();
        }
        else if (!floatup)
        {
            floatingdown();
        }

        //rail change
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(this.transform.position.x == Middle.transform.position.x)
            {
                /*Vector3 position = this.transform.position;
                position.x = Right.transform.position.x;
                this.transform.position = position;*/
                Vector3 position = this.transform.position;
                position.x = Mathf.Lerp(position.x, Right.transform.position.x, 1f);
                this.transform.position = position;

            }
            else if(this.transform.position.x == Left.transform.position.x)
            {
                /*Vector3 position = this.transform.position;
                position.x = Middle.transform.position.x;
                this.transform.position = position;*/
                Vector3 position = this.transform.position;
                position.x = Mathf.Lerp(position.x, Middle.transform.position.x, 1f);
                this.transform.position = position;
            }

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(this.transform.position.x == Middle.transform.position.x)
            {
                /*Vector3 position = this.transform.position;
                position.x = Left.transform.position.x;
                this.transform.position = position;*/
                Vector3 position = this.transform.position;
                position.x = Mathf.Lerp(position.x, Left.transform.position.x, 1f);
                this.transform.position = position;
            }
            else if(this.transform.position.x == Right.transform.position.x)
            {
                /*Vector3 position = this.transform.position;
                position.x = Middle.transform.position.x;
                this.transform.position = position;*/
                Vector3 position = this.transform.position;
                position.x = Mathf.Lerp(position.x, Middle.transform.position.x, 1f);
                this.transform.position = position;
            }
        }
	}

    void floatingup()
    {
        Vector3 pos = transform.position;
        pos.y +=(float) 1.5 * Time.deltaTime;//Facteur à changer potentiellement
        transform.position = pos;

       // yield return new WaitForSeconds((float)0.5);

        floatup = false;
       
    }

    void floatingdown()
    {
        Vector3 pos = transform.position;
        pos.y -= (float)1.5 * Time.deltaTime;//Facteur à changer potentiellement
        transform.position = pos;

        //yield return new WaitForSeconds((float)0.5);

        floatup = true;
    }

}
