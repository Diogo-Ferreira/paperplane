using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smooth : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            StartCoroutine(Move_Routine(this.transform, this.transform.position, new Vector3(-5, 0, 0) + this.transform.position));
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {

            StartCoroutine(Move_Routine(this.transform, this.transform.position, new Vector3(5, 0, 0) + this.transform.position));
        }

    }

    private IEnumerator Move_Routine(Transform transform, Vector3 from, Vector3 to)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;
            var save = transform.position;
            save.x = Hermite(from.x, to.x, t);
            save.y = Hermite(from.y, to.y, t);
            save.z = Hermite(from.z, to.z, t);
            transform.position = save;
            yield return null;
        }
    }

    //Ease in out
    public static float Hermite(float start, float end, float value)
    {
        return Mathf.Lerp(start, end, value * value * (3.0f - 2.0f * value));
    }
}
