using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class path : MonoBehaviour {

    //Rail thing
    public GameObject Left;
    public GameObject Right;
    public GameObject Middle;

    public float accumulateur;

    //Tell if the player is alive
    public bool isAlive;


	// Use this for initialization
	void Start () {
        accumulateur = 0;
        isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
        //go to z axe
        Vector3 pos = this.transform.position;
        pos.z += (float)0.1;
        this.transform.position = pos;

        //rail change
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(this.transform.position.x == Middle.transform.position.x)
            {
                StartCoroutine(Move_Routine(this.transform, this.transform.position, new Vector3(Right.transform.position.x, this.transform.position.y, 0)));

            }
            else if(this.transform.position.x == Left.transform.position.x)
            {
                StartCoroutine(Move_Routine(this.transform, this.transform.position, new Vector3(Middle.transform.position.x, this.transform.position.y, 0)));
            }

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(this.transform.position.x == Middle.transform.position.x)
            {
                StartCoroutine(Move_Routine(this.transform, this.transform.position, new Vector3(Left.transform.position.x, this.transform.position.y, 0)));
            }
            else if(this.transform.position.x == Right.transform.position.x)
            {
                StartCoroutine(Move_Routine(this.transform, this.transform.position, new Vector3(Middle.transform.position.x, this.transform.position.y, 0)));
            }
        }
	}

    void FixedUpdate()
    {
        //floating
        accumulateur += Time.deltaTime;
        Vector3 positionFloat = this.transform.position;
        positionFloat.y += 0.025f*Mathf.Sin(5f*accumulateur);
        this.transform.position = positionFloat;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Touche");
        isAlive = false;
    }

    private IEnumerator Move_Routine(Transform transform, Vector3 from, Vector3 to)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += 2*Time.deltaTime;
            var save = transform.position;
            save.x = Hermite(from.x, to.x, t);
            //save.y = Hermite(from.y, to.y, t);
            //save.z = Hermite(from.z, to.z, t);
            transform.position = save;
            yield return null;
        }

        var save2 = transform.position;
        save2.x = to.x;
        transform.position = save2;
    }

    //Ease in out
    public static float Hermite(float start, float end, float value)
    {
        return Mathf.Lerp(start, end, value * value * (3.0f - 2.0f * value));
    }
}
