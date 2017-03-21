using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionController : MonoBehaviour {


    List<Vector3> positions;
    public GameObject SitdownStudent;
    public GameObject StandupStudent;

	// Use this for initialization
	void Start () {
        this.positions = new List<Vector3>();
        var positionObjects = GameObject.FindGameObjectsWithTag("StudentPosition");
        foreach(var position in positionObjects)
        {
            positions.Add(position.transform.position);
        }

        Debug.Log(positions.ToString());

        InitStudents(new int[] {1,0,1,0,1,0,1});
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void InitStudents(int[] values)
    {
        for(int i=0; i<values.Length; i++)
        {
            var typeStudent = values[i] == 0 ? SitdownStudent : StandupStudent; 
            var obj = Instantiate(typeStudent) as GameObject;

            obj.transform.position = positions[i];
            obj.transform.Translate(0, obj.GetComponent<Renderer>().bounds.size.y/2, 0);
        }
    }
}
